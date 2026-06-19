using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.Services;
using MyPortfolio.Application.Services.Abouts;
using MyPortfolio.Application.Services.ContactMessage;
using MyPortfolio.Application.Services.Education;
using MyPortfolio.Application.Services.Language;
using MyPortfolio.Application.Services.Profile;
using MyPortfolio.Application.Services.Skill;
using MyPortfolio.Application.Services.WorkExperience;
using MyPortfolio.Application.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPortfolio.EndPoint_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IAboutService _about;
        private readonly ISkillService skillService;
        private readonly IProjectService projectService;
        private readonly IWorkExperienceService experienceService;
        private readonly IEducationService educationService;
        private readonly ILanguageService languageService;
        private readonly IContactMessageService _contactMessageService;

        public HomeController(IProfileService profileService, IAboutService about, ISkillService skillService, IProjectService projectService, IWorkExperienceService experienceService, IEducationService educationService, ILanguageService languageService, IContactMessageService contactMessageServic)
        {
            this.profileService = profileService;
            _about = about;
            this.skillService = skillService;
            this.projectService = projectService;
            this.experienceService = experienceService;
            this.educationService = educationService;
            this.languageService = languageService;
            _contactMessageService = contactMessageServic;
        }

        public async Task<IActionResult>  Index()
        {
            var profileDto = await profileService.GetProfileAsync();
            var aboutDto = await _about.GetAboutAsync();
            var skills = await skillService.GetPagedSkillsAsync(1, 20);
            var projects = await projectService.GetPagedProjectsAsync(1, 20);
            var expriences = await experienceService.GetPagedWorkExperienceAsync(1, 20);
            var educations = await educationService.GetPagedEducationAsync(1, 20);
            var languages = await languageService.GetPagedLanguageAsync(1, 20);

            var model = new PortfolioViewModel
            {
                Profile = new ProfileViewModel
                {
                    FullNameFa = profileDto.FullNameFa,
                    FullNameEn = profileDto.FullNameEn,
                    JobTitleFa = profileDto.JobTitleFa,
                    JobTitleEn = profileDto.JobTitleEn,
                    ImageName = profileDto.ImageName,
                   DescriptionFa=profileDto.DescriptionFa,
                   DescriptionEn=profileDto.DescriptionEn
                },
              

                 AboutDescription= new AboutViewModel
                 {

                     DescriptionEn=aboutDto.DescriptionEn,
                     DescriptionFa=aboutDto.DescriptionFa
                 },
                 

                Skills = skills,
                Projects = projects,

                Experiences = expriences,
                Educations = educations,
                Languages= languages

            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMessage(ContactMessageViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var dto = new ContactMessageDto
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            };

            await _contactMessageService.CreateMessageAsync(dto);

            return RedirectToAction("Index");
        }


    }
}
