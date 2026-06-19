using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services.WorkExperience;
using MyPortfolio.Application.ViewModels;

namespace MyPortfolio.EndPoint_UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class WorkExperienceController : Controller
    {
        private readonly IWorkExperienceService workExperience;

        public WorkExperienceController(IWorkExperienceService workExperience)
        {
            this.workExperience = workExperience;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 6;

            var model = await workExperience.GetPagedWorkExperienceAsync(page, pageSize);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new WorkExperienceViewModel());
         }

        [HttpPost]
        public async Task<IActionResult> Create(WorkExperienceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new WorkExperienceDto()
            {
                Id = model.Id,
                TitleFa = model.TitleFa,
                TitleEn = model.TitleEn,

                CompanyNameFa = model.CompanyNameFa,
                CompanyNameEn = model.CompanyNameEn,

                DateOfStart = model.DateOfStart,
                DateOfEnd = model.DateOfEnd,
                DescriptionFa = model.DescriptionFa,
                DescriptionEn = model.DescriptionEn




            };
            await workExperience.CreateWorkExperienceAsync(dto);

            return RedirectToAction("Index", "WorkExperience");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var exprience = await workExperience.GetWorkExperiencetByIdAsync(id);
            if (exprience == null)
                return NotFound();

            var model = new WorkExperienceViewModel()
            {
                Id = exprience.Id,
                TitleFa = exprience.TitleFa,
                TitleEn = exprience.TitleEn,

                CompanyNameFa = exprience.CompanyNameFa,
                CompanyNameEn = exprience.CompanyNameEn,

                DateOfStart = exprience.DateOfStart,
                DateOfEnd = exprience.DateOfEnd,
                DescriptionFa = exprience.DescriptionFa,
                DescriptionEn = exprience.DescriptionEn


            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(WorkExperienceViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new WorkExperienceDto()
            {
                Id = vm.Id,
                TitleFa = vm.TitleFa,
                TitleEn = vm.TitleEn,

                CompanyNameFa = vm.CompanyNameFa,
                CompanyNameEn = vm.CompanyNameEn,
                
                DateOfStart = vm.DateOfStart,
                DateOfEnd = vm.DateOfEnd,
                DescriptionFa = vm.DescriptionFa,
                DescriptionEn = vm.DescriptionEn
            };

            await workExperience.UpdateWorkExperienceAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await workExperience.DeleteWorkExperienceAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }





}

