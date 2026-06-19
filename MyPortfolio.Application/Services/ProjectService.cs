using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contract;
using MyPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using System.Runtime.InteropServices;


namespace MyPortfolio.Application.Services
{
   public class ProjectService : IProjectService
  { private readonly IContext _context;

        public ProjectService(IContext context)
        {
            _context = context;
        }

        public async Task CreateProjectAsync(ProjectDto dto)
        {
            var entity = new ProjectEntity
            {
                TitleFa = dto.TitleFa,
                TitleEn=dto.TitleEn,
                DescriptionFa = dto.DescriptionFa,
                DescriptionEn = dto.DescriptionEn,

                GithubUrl = dto.GithubUrl,
                ProjectImagePath=dto.ImageName


            };

            _context.Set<ProjectEntity>().Add(entity);


            await _context.SaveChangesAsync();

        }
        public async Task DeleteProjectAsync(Guid ProjectId)
        {
            ProjectEntity? entity =
                await _context.Set<ProjectEntity>()
                .FirstOrDefaultAsync(f => f.Id == ProjectId);

            if (entity == null)
            {
                 throw new Exception("پروژه‌ای با این شناسه یافت نشد.");
            }
            entity.IsDelete = true;
            _context.Set<ProjectEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

       

        public async Task<PagedListViewModel<ProjectViewModel>> GetPagedProjectsAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<ProjectEntity>().Where(p => !p.IsDelete); 
            int totalProjects = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;
            var items = await
                query.OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .Select(x => new ProjectViewModel

                {
                    Id = x.Id,
                    TitleFa = x.TitleFa,
                    TitleEn=x.TitleEn,
                    GithubUrl = x.GithubUrl,
                    DescriptionFa=x.DescriptionFa,
                    DescriptionEn = x.DescriptionEn,
                    ImageName= x.ProjectImagePath

                }



                ).ToListAsync();

            return new PagedListViewModel<ProjectViewModel>
            {
                Items = items,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalProjects
            };


        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {

            var project = await _context.Set<ProjectEntity>().FindAsync(id);

            if (project == null)
               
                return null;

            var dto = new ProjectDto()
            {   
                Id=project.Id,
                TitleFa = project.TitleFa,
                TitleEn= project.TitleEn,
                DescriptionFa=project.DescriptionFa,
                DescriptionEn=project.DescriptionEn,
                GithubUrl=project.GithubUrl,
                ImageName=project.ProjectImagePath

            };

            return dto;



        }

        public async Task UpdateProjectAsync(ProjectDto dto)
        {
            var project = await _context.Set<ProjectEntity>().FindAsync(dto.Id);

            if(project==null)
                throw new Exception("پروژه‌ای با این شناسه یافت نشد.");
            project.TitleFa = dto.TitleFa;
            project.TitleEn = dto.TitleEn;
            project.DescriptionFa = dto.DescriptionFa;
            project.DescriptionEn = dto.DescriptionEn;

            project.GithubUrl = dto.GithubUrl;
            project.ProjectImagePath = dto.ImageName;
            await _context.SaveChangesAsync();

           
        }

        
    }//end of class
}//end of namespace
