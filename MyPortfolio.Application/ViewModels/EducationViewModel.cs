using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
    public class EducationViewModel
    { public Guid Id { get; set; } = default;
        public string Title { get; set; } = default!;
        public string InstituteName { get; set; } = default!;
        public string DateOfStart { get; set; }
        public string DateOfEnd { get; set; }

        public string? Description { get; set; } = default;

        

    }
}
