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

        [Required]
        public string Title { get; set; } = default!;
        public string GithubUrl { get; set; } = default!;
        public string Description { get; set; } = default!;

    }
}
