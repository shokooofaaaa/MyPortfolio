using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class EducationEntity:BaseEntity
    {

        public string Title { get; set; } = default!;
        public string InstituteName { get; set; } = default!;
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
       
        public string? Description { get; set; }

        public bool IsDelete { get; set; } = false;

    }
}
