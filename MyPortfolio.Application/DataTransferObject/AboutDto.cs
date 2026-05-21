using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.DataTransferObject
{
   public record AboutDto
    {
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFa { get; set; }

    }
}
