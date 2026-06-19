using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
   public record PortfolioViewModel
    {
       public PagedListViewModel<ProjectViewModel> Projects { get; set; }
        public PagedListViewModel<SkillViewModel> Skills { get; set; }
        public PagedListViewModel<WorkExperienceViewModel> Experiences{ get; set; }
        public PagedListViewModel<EducationViewModel> Educations { get; set; }
        public PagedListViewModel<LanguageViewModel> Languages { get; set; }

        public ProfileViewModel Profile { get; set; }

        public ContactMessageViewModel ContactMessage { get; set; }
        public AboutViewModel AboutDescription { get; set; }
    }
}
