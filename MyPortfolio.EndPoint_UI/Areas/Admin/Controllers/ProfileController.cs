using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services.Profile;
using MyPortfolio.Application.ViewModels;
using System.Net.WebSockets;

namespace MyPortfolio.EndPoint_UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var dto = await _profileService.GetProfileAsync();

            var vm = new ProfileViewModel()
            {
                FullNameFa = dto.FullNameFa,
                FullNameEn = dto.FullNameEn,
                JobTitleFa = dto.JobTitleFa,
                JobTitleEn = dto.JobTitleEn,
                ImageName = dto.ImageName
            };

            return View(vm);

           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile imageFile,ProfileDto dto)
        {



            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profile");

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
            await _profileService.UpdateProfileAsync(dto);

            return RedirectToAction("Edit");
        }

    }
}
