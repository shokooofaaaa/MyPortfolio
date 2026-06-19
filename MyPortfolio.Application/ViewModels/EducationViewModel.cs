using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
    public record EducationViewModel
    { public Guid Id { get; set; } = default;
        public string DateOfStart { get; set; }
        public string DateOfEnd { get; set; }


        public string TitleFa { get; set; } = default!;
        public string TitleEn { get; set; } = default!;
        public string InstituteNameFa { get; set; } = default!;
        public string InstituteNameEn { get; set; } = default!;
        public string DescriptionFa { get; set; } = default!;

        public string DescriptionEn { get; set; } = default!;

    }
}
