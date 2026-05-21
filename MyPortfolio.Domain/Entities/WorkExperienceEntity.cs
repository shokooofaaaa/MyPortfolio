using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class WorkExperienceEntity:BaseEntity
    {

     
        public string Title { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public string Description { get; set; } = default!;
        public bool IsDelete { get; set; } = false;

    }
}
