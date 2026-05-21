using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Abouts
{
    public interface IAboutService
    {
        Task<AboutViewModel> GetAboutAsync();
        Task SaveAboutAsync(AboutDto dto);

    }
}
