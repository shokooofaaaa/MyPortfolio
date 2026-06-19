using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.DataTransferObject
{
    public record ProfileDto
    {
        public string FullNameEn { get; set; }
        public string FullNameFa { get; set; }

        public string JobTitleEn { get; set; }
        public string JobTitleFa { get; set; }

        public string? ImageName { get; set; }

        public string DescriptionFa { get; set; }
        public string DescriptionEn { get; set; }




    }
}
