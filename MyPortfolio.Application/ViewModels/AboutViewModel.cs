using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
    public record AboutViewModel
    {
        public string DescriptionEn { get; set; }
        public string DescriptionFa { get; set; }
    }
}
