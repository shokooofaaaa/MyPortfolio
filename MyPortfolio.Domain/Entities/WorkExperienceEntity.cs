using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class WorkExperienceEntity:BaseEntity
    {

     
        public string TitleFa { get; set; } = default!;
        public string TitleEn { get; set; } = default!;
        public string CompanyNameFa { get; set; } = default!;
        public string CompanyNameEn { get; set; } = default!;
        public string DescriptionFa { get; set; } = default!;

        public string DescriptionEn { get; set; } = default!;

        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
      
        public bool IsDelete { get; set; } = false;

    }
}
