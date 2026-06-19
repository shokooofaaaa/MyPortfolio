using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services.Abouts;
using MyPortfolio.Application.ViewModels;

namespace MyPortfolio.EndPoint_UI.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _aboutService.GetAboutAsync();

            if (model == null)
            {
                model = new AboutViewModel
                {
                    DescriptionFa = string.Empty,
                    DescriptionEn=string.Empty
                };
            }

            return View("~/Areas/Admin/Views/About.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AboutDto dto)
        {
           

            await _aboutService.SaveAboutAsync(dto);

            return RedirectToAction(nameof(Index));
        }





    }
}
