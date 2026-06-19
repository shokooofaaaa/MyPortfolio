using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
   public record LanguageViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }
    }
}
