using Application.Common.Extension;
using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.WorkExperience
{
   public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IContext _context;

        public WorkExperienceService(IContext context)
        {
            _context = context;
        }

        public async Task CreateWorkExperienceAsync(WorkExperienceDto dto)
        {
            var entity = new WorkExperienceEntity()
            {
                Id=dto.Id,
               Title = dto.Title,
               CompanyName=dto.CompanyName,
               DateOfStart = dto.DateOfStart.ConvertToGregorian(),

                DateOfEnd = string.IsNullOrWhiteSpace(dto.DateOfEnd) || dto.DateOfEnd == "تا اکنون"
            ? null
            : dto.DateOfEnd.ConvertToGregorian(),

                Description = dto.Description   };

            _context.Set<WorkExperienceEntity>().Add(entity);

            await _context.SaveChangesAsync();
            
        }


       public async Task  DeleteWorkExperienceAsync(Guid ExprienceId)
        {
           WorkExperienceEntity entity = await _context.Set<WorkExperienceEntity>()
                           .FirstOrDefaultAsync(f => f.Id == ExprienceId);

           if (entity == null)
            {
                throw new Exception("تجربه ای با این شناسه یافت نشد.");
            }
            entity.IsDelete = true;
            _context.Set<WorkExperienceEntity>().Update(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<PagedListViewModel<WorkExperienceViewModel>> GetPagedWorkExperienceAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<WorkExperienceEntity>().Where(x => !x.IsDelete);

            int totalExperiences = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var items = await query
          .OrderByDescending(x => x.Id)
          .Skip(skip)
          .Take(take)
          .ToListAsync(); 

            var result = items.Select(x => new WorkExperienceViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CompanyName = x.CompanyName,
                DateOfStart = x.DateOfStart.PersianDateWithOutTime(),
                DateOfEnd = x.DateOfEnd.HasValue
                           ? Time.PersianDateWithOutTime(x.DateOfEnd.Value)
                           : "تا اکنون",

                Description = x.Description
            }).ToList();


            return new PagedListViewModel<WorkExperienceViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalExperiences
            };






        }

        public async Task<WorkExperienceDto> GetWorkExperiencetByIdAsync(Guid id)
        {
            var exprience = await _context.Set<WorkExperienceEntity>().FindAsync(id);

            if (exprience == null)

                return null;

            var ExprienceDto = new WorkExperienceDto()
            {
                Id = exprience.Id,
                Title = exprience.Title,
                CompanyName = exprience.CompanyName,
                DateOfStart = exprience.DateOfStart.PersianDateWithOutTime(),
                DateOfEnd = exprience.DateOfEnd.HasValue
                             ? Time.PersianDateWithOutTime(exprience.DateOfEnd.Value)
                             : "تا اکنون",

                Description = exprience.Description




            };

            return ExprienceDto;

        }

        public async Task UpdateWorkExperienceAsync(WorkExperienceDto dto)
        {
            var exprience = await _context.Set<WorkExperienceEntity>().FindAsync(dto.Id);

            if (exprience == null)
                throw new Exception("تجربه ای با این شناسه یافت نشد");

            exprience.Title = dto.Title;
            exprience.CompanyName = dto.CompanyName;
            exprience.DateOfStart = dto.DateOfStart.ConvertToGregorian();

            if (!string.IsNullOrWhiteSpace(dto.DateOfEnd) && dto.DateOfEnd != "تا اکنون")
                exprience.DateOfEnd = dto.DateOfEnd.ConvertToGregorian();
            else
                exprience.DateOfEnd = null; 

            
            exprience.Description = dto.Description;

            await _context.SaveChangesAsync();

        }
    }
}
