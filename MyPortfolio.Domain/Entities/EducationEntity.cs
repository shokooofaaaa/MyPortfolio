using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class EducationEntity:BaseEntity
    {
        public string TitleFa { get; set; } = default!;
        public string TitleEn { get; set; } = default!;
        public string InstituteNameFa { get; set; } = default!;
        public string InstituteNameEn { get; set; } = default!;
        public string DescriptionFa { get; set; } = default!;

        public string DescriptionEn { get; set; } = default!;

        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
       

        public bool IsDelete { get; set; } = false;

    }
}
