using EndPointUI.Models;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services.Skill;
using MyPortfolio.Application.ViewModels;

namespace MyPortfolio.EndPoint_UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
           const int pageSize = 6;

           var pagedSkills = await _skillService.GetPagedSkillsAsync(page, pageSize);

            var viewModel = new SkillIndexViewModel
            {    
                Skills=pagedSkills,

              SkillForm = new SkillViewModel()



            };

           return View(viewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillIndexViewModel skillModel)
        {
            var dto = new SkillDto
            {
                Name = skillModel.SkillForm.Name,
                Level = skillModel.SkillForm.Level

            };

            await _skillService.CreateSkillAsync(dto);

            return RedirectToAction("Index", "Skill");

        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid Id)
        {

            if (Id == Guid.Empty) return NotFound();
            var skill = await _skillService.GetSkillById(Id);

            if (skill == null)
                return NotFound();

            return View(skill);
         }


        [HttpPost]

        public async Task<IActionResult> Edit(SkillDto dto)
        { 

            if (!ModelState.IsValid)
                return View(dto);

            await _skillService.UpdateSkillAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _skillService.DeleteSkillAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
