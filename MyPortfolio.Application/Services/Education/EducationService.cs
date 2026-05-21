using Application.Contract;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Extension;
using Microsoft.EntityFrameworkCore;


namespace MyPortfolio.Application.Services.Education
{
   public class EducationService : IEducationService
    {
        private readonly IContext _context;

        public EducationService(IContext context)
        {
            _context = context;
        }

        public async Task CreateEducationAsync(EducationDto dto)
        {
            var entity = new EducationEntity()
            {    Id=dto.Id,
                Title=dto.Title,
                InstituteName = dto.InstituteName,
                DateOfStart = dto.DateOfStart.ConvertToGregorian(),

                DateOfEnd = string.IsNullOrWhiteSpace(dto.DateOfEnd) || dto.DateOfEnd == "تا اکنون"
            ? null
            : dto.DateOfEnd.ConvertToGregorian(),
                Description = dto.Description
               };

            _context.Set<EducationEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEducationAsync(Guid id)
        {
            EducationEntity entity = await _context.Set<EducationEntity>().FirstOrDefaultAsync(f => f.Id == id);

            if(entity == null)
            {
                throw new Exception("تحصیلاتی یافت نشد");

            }

            entity.IsDelete = true;
            _context.Set<EducationEntity>().Update(entity);

           await _context.SaveChangesAsync();
        }

        public async Task<EducationDto> GetEducationByIdAsync(Guid id)
        {
            var education = await _context.Set<EducationEntity>().FindAsync(id);

            if (education == null)

                return null;

            var dto = new EducationDto()
            {
                Id = education.Id,
                Title = education.Title,
                InstituteName = education.InstituteName,
                DateOfStart = education.DateOfStart.PersianDateWithOutTime(),

                DateOfEnd = education.DateOfEnd.HasValue
                             ? Time.PersianDateWithOutTime(education.DateOfEnd.Value)
                             : "تا اکنون",

                Description = education.Description

               


            };

            return dto;

        }

        public async Task<PagedListViewModel<EducationViewModel>> GetPagedEducationAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<EducationEntity>().Where(x => !x.IsDelete);

            int totalEducations = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var items = await query
          .OrderByDescending(x => x.Id)
          .Skip(skip)
          .Take(take)
          .ToListAsync();

            var result = items.Select(x => new EducationViewModel
            {
                Id = x.Id,
                Title = x.Title,
                InstituteName = x.InstituteName,
                DateOfStart = x.DateOfStart.PersianDateWithOutTime(),
                DateOfEnd = x.DateOfEnd.HasValue
                           ? Time.PersianDateWithOutTime(x.DateOfEnd.Value)
                           : "تا اکنون",

                Description = x.Description
            }).ToList();


            return new PagedListViewModel<EducationViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalEducations
            };


        }

        public async Task UpdateEducationAsync(EducationDto dto)
        {
            var education = await _context.Set<EducationEntity>().FindAsync(dto.Id);

            if (education == null)
                throw new Exception("تحصیلاتی با این شناسه یافت نشد");

            education.Title = dto.Title;
            education.InstituteName = dto.InstituteName;
            education.DateOfStart = dto.DateOfStart.ConvertToGregorian();

            if (!string.IsNullOrWhiteSpace(dto.DateOfEnd) && dto.DateOfEnd != "تا اکنون")
                education.DateOfEnd = dto.DateOfEnd.ConvertToGregorian();
            else
                education.DateOfEnd = null;


            education.Description = dto.Description;

            await _context.SaveChangesAsync();
        }
    }
}
