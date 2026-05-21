using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string GithubUrl { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsDelete { get; set; } = false;

    }
}
