using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfileAsync();
        Task UpdateProfileAsync(ProfileDto dto);


    }
}
