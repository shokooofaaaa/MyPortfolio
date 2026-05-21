using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services.Education;
using MyPortfolio.Application.ViewModels;

namespace MyPortfolio.EndPoint_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationService _education;

        public EducationController(IEducationService education)
        {
            _education = education;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 6;

            var model = await _education.GetPagedEducationAsync(page, pageSize);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new EducationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new EducationDto()
            {
                Id = model.Id,
                Title = model.Title,
                InstituteName = model.InstituteName,
                DateOfStart = model.DateOfStart,
                DateOfEnd = model.DateOfEnd,
                Description = model.Description



            };
            await _education.CreateEducationAsync(dto);

            return RedirectToAction("Index", "Education");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var education = await _education.GetEducationByIdAsync(id);
            if (education == null)
                return NotFound();

            var model = new EducationViewModel()
            {
                Id = education.Id,
                Title = education.Title,
                InstituteName = education.InstituteName,
                DateOfStart = education.DateOfStart,
                DateOfEnd = education.DateOfEnd,
                Description = education.Description

            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EducationViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new EducationDto()
            {
                Id = vm.Id,
                Title = vm.Title,
                InstituteName = vm.InstituteName,
                DateOfStart = vm.DateOfStart,
                DateOfEnd = vm.DateOfEnd,
                Description = vm.Description
            };

            await _education.UpdateEducationAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _education.DeleteEducationAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
