using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
    public record ProjectViewModel
    {
        public Guid Id { get; set; } = default!;
        public string GithubUrl { get; set; } = default!;
        public string? DescriptionFa { get; set; } = default!;
        public string? DescriptionEn { get; set; } = default!;

        public string? TitleFa { get; set; } = default!;
        public string? TitleEn { get; set; } = default!;
        public string? ImageName { get; set; }

    }
}
