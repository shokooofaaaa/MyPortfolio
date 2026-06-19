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
                TitleFa = model.TitleFa,
                TitleEn = model.TitleEn,

                InstituteNameFa = model.InstituteNameFa,
                InstituteNameEn = model.InstituteNameEn,

                DateOfStart = model.DateOfStart,
                DateOfEnd = model.DateOfEnd,
                DescriptionFa = model.DescriptionFa,
                DescriptionEn = model.DescriptionEn,



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
                TitleFa = education.TitleFa,
                TitleEn = education.TitleEn,

                InstituteNameFa = education.InstituteNameFa,
                InstituteNameEn = education.InstituteNameEn,

                DateOfStart = education.DateOfStart,
                DateOfEnd = education.DateOfEnd,
                DescriptionFa = education.DescriptionFa,
                DescriptionEn = education.DescriptionEn,


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
                TitleFa = vm.TitleFa,
                TitleEn = vm.TitleEn,

                InstituteNameFa = vm.InstituteNameFa,
                InstituteNameEn = vm.InstituteNameEn,

                DateOfStart = vm.DateOfStart,
                DateOfEnd = vm.DateOfEnd,
                DescriptionFa = vm.DescriptionFa,
                DescriptionEn = vm.DescriptionEn,
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
