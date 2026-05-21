using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Profile
{
   public class ProfileService : IProfileService
    {
        private readonly IContext context;

        public ProfileService(IContext context)
        {
            this.context = context;
        }

        public async Task<ProfileDto> GetProfileAsync()
        {
            var profileEntity = await context.Set<ProfileEntity>()
                .FirstOrDefaultAsync();

            if (profileEntity == null)
            {
                return new ProfileDto();

            }

            return new ProfileDto()
            {
                FullNameFa = profileEntity.FullNameFa,

                FullNameEn = profileEntity.FullNameEn,


                JobTitleFa = profileEntity.JobTitleFa,

                JobTitleEn = profileEntity.JobTitleEn,

                ImageName = profileEntity.ProfileImagePath


            };
            }

        public async Task UpdateProfileAsync(ProfileDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var profileEntity = await context.Set<ProfileEntity>()
                 .FirstOrDefaultAsync();

            if(profileEntity == null)
            {


                profileEntity = new ProfileEntity
                {
                    Id = Guid.NewGuid(),
                     FullNameEn=dto.FullNameEn,
                     FullNameFa=dto.FullNameFa,
                     JobTitleEn=dto.JobTitleEn,
                     JobTitleFa =dto.JobTitleFa,

                     ProfileImagePath = dto.ImageName

    };

                context.Set<ProfileEntity>().Add(profileEntity);

            }

            else
            {
                profileEntity.FullNameEn = dto.FullNameEn;
                profileEntity.FullNameFa = dto.FullNameFa;
                profileEntity.JobTitleEn = dto.JobTitleEn;
                profileEntity.JobTitleFa = dto.JobTitleFa;

                profileEntity.ProfileImagePath = dto.ImageName;


            }

            await context.SaveChangesAsync();



        }
    }
}
