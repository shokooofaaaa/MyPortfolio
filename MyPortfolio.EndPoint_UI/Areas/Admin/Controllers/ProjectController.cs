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
        public async Task<IActionResult> Create(IFormFile imageFile, ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new ProjectDto()
            {
                Id = model.Id,
                TitleFa = model.TitleFa,
                TitleEn = model.TitleEn,
                DescriptionFa = model.DescriptionFa,
                DescriptionEn = model.DescriptionEn,

                GithubUrl = model.GithubUrl,
                ImageName = model.ImageName 
            };

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "project");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                dto.ImageName = uniqueFileName;
            }

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
                TitleFa = project.TitleFa,
                TitleEn = project.TitleEn,

                DescriptionFa = project.DescriptionFa,

                DescriptionEn = project.DescriptionEn,

                GithubUrl = project.GithubUrl,
               ImageName = project.ImageName


            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile imageFile,ProjectViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new ProjectDto()
            {
                Id = vm.Id,
                TitleFa = vm.TitleFa,
                TitleEn = vm.TitleEn,

                DescriptionFa = vm.DescriptionFa,

                DescriptionEn = vm.DescriptionEn,

                GithubUrl = vm.GithubUrl,
                ImageName = vm.ImageName

            };

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "project");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                dto.ImageName = uniqueFileName;

            }
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

