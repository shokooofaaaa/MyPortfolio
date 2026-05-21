using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Infrastructure.Context;
using MyPortfolio.EndPoint_UI.Models;
using MyPortfolio.Domain.Entities;
using MyPortfolio.Application.Services;
using MyPortfolio.Application.DataTransferObject;
using System.Reflection.Metadata.Ecma335;
using EndPointUI.Models;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Application.Services.Language;


namespace MyPortfolio.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {

        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 6;

            var model = await _languageService.GetPagedLanguageAsync(page, pageSize);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {



            return View(new LanguageViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var dto = new LanguageDto()
            {
                Id = model.Id,
                
                Name=model.Name,
                Level = model.Level


            };




            await _languageService.CreateLanguageAsync(dto);

            return RedirectToAction("Index", "Language");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var language = await _languageService.GetLanguageById(id);
            if (language == null)
                return NotFound();

            var model = new LanguageViewModel()
            {
                Id = language.Id,

                Name = language.Name,
                Level = language.Level


            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LanguageViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = new LanguageDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Level = vm.Level
            };

            await _languageService.UpdateLanguageAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _languageService.DeleteLanguageAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}
