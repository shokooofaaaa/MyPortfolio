using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.DataTransferObject
{
    public record WorkExperienceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string DateOfStart { get; set; }
        public string DateOfEnd { get; set; }
        public string Description { get; set; } = default!;
    }
}
