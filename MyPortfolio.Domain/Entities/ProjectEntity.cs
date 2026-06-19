using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public string? TitleFa { get; set; } = default!;
        public string? TitleEn { get; set; } = default!;

        public string? GithubUrl { get; set; } = default!;
        public string? DescriptionFa { get; set; } = default!;
        public string? DescriptionEn { get; set; } = default!;

        public bool IsDelete { get; set; } = false;
        public string? ProjectImagePath { get; set; }

    }
}
