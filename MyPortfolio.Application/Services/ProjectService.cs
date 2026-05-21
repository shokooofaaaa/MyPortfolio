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
                Title = dto.Title,
                Description = dto.Description,
                GithubUrl = dto.GithubUrl



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
                    Title = x.Title,
                    GithubUrl = x.GithubUrl,
                    Description=x.Description


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
                Title = project.Title,
                Description=project.Description,
                GithubUrl=project.GithubUrl

            };

            return dto;



        }

        public async Task UpdateProjectAsync(ProjectDto dto)
        {
            var project = await _context.Set<ProjectEntity>().FindAsync(dto.Id);

            if(project==null)
                throw new Exception("پروژه‌ای با این شناسه یافت نشد.");
            project.Title = dto.Title;
            project.Description = dto.Description;
            project.GithubUrl = dto.GithubUrl;

            await _context.SaveChangesAsync();

           
        }

        
    }//end of class
}//end of namespace
