using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Infrastructure.Context;
using MyPortfolio.EndPoint_UI.Models;
using MyPortfolio.Domain.Entities;
using MyPortfolio.Application.Services;
using MyPortfolio.Application.DataTransferObject;
using System.Reflection.Metadata.Ecma335;
using EndPointUI.Models;
using MyPortfolio.Application.ViewModels;


namespace MyPortfolio.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {

        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 6;

            var model = await _projectService.GetPagedProjectsAsync(page, pageSize);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {  

           

           return View(new ProjectViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var dto = new ProjectDto()
            { Id=model.Id,
              Title = model.Title,
              Description=model.Description,
              GithubUrl = model.GithubUrl
            
            
            };

          


            await _projectService.CreateProjectAsync(dto);

            return RedirectToAction("Index", "Project");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            var model = new ProjectViewModel()
            {    Id=project.Id,
                Title = project.Title,
                Description=project.Description,
                GithubUrl = project.GithubUrl


            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProjectDto()
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                GithubUrl = vm.GithubUrl
            };

            await _projectService.UpdateProjectAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}

