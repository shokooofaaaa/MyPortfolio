using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Application.ViewModels
{
    public class DashboardViewModel
    {

        public List<WorkExperienceEntity> WorkExperiences { get; set; }
        public List<SkillEntity> Skills { get; set; }
        public List<ProjectEntity> Projects { get; set; }
        public string AboutDescription { get; set; }

        public ProjectEntity NewProject { get; set; }
    }
}
