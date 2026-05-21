using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
   public class SkillIndexViewModel
    {
      public  PagedListViewModel<SkillViewModel> Skills { get; set; }

       public SkillViewModel SkillForm { get; set; }



    }
}
