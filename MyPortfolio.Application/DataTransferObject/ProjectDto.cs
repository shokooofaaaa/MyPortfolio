using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.DataTransferObject
{
    public record ProjectDto
    {
        public Guid Id { get; set; }
        public string? DescriptionFa { get; set; } = default!;
        public string? DescriptionEn { get; set; } = default!;

        public string? TitleFa { get; set; } = default!;
        public string? TitleEn { get; set; } = default!;
        [Required]
        public string GithubUrl { get; set; } = default!;
        public string ImageName { get; set; }

    }
}
