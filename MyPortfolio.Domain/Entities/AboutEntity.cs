using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Domain.Entities
{
   public class AboutEntity : BaseEntity
    {
        public string DescriptionEn { get; set; }
        public string DescriptionFa { get; set; }


    }
}
