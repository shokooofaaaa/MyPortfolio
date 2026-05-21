using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Domain.Entities
{
   public class LanguageEntity :BaseEntity
    {
        public string Name { get; set; }

        public int Level { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}
