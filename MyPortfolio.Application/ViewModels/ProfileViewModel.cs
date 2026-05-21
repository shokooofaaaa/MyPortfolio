using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Domain.Entities;

using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Application.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "لطفا نام فارسی را وارد کنید")]
        public string FullNameFa { get; set; }

        [Required(ErrorMessage = "لطفا نام انگلیسی را وارد کنید")]
        public string FullNameEn { get; set; }

        [Required(ErrorMessage = "لطفا عنوان شغلی فارسی را وارد کنید")]
        public string JobTitleFa { get; set; }

        [Required(ErrorMessage = "لطفا عنوان شغلی انگلیسی را وارد کنید")]
        public string JobTitleEn { get; set; }

        public string? ImageName { get; set; }


    }
}
