using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MyPortfolio.Application.ViewModels;
namespace MyPortfolio.Application.Services.Abouts
{
   public class AboutService:IAboutService
    {
        private readonly IContext _context;

        public AboutService(IContext context)
        {
            _context = context;
        }

        public async Task<AboutViewModel> GetAboutAsync()
        {
            var aboutEntity = await _context.Set<AboutEntity>()
                .FirstOrDefaultAsync();

            if (aboutEntity == null)
            {
                return new AboutViewModel();
            }
            return new AboutViewModel()
            {
                

                DescriptionEn = aboutEntity.DescriptionEn,
                DescriptionFa = aboutEntity.DescriptionFa

            };

        }

        public async Task SaveAboutAsync(AboutDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var aboutEntity = await _context.Set<AboutEntity>()
                .FirstOrDefaultAsync();

            if (aboutEntity == null)
            {
                aboutEntity = new AboutEntity
                {
                    Id = Guid.NewGuid(),
                    DescriptionFa = dto.DescriptionFa ?? string.Empty,
                    DescriptionEn = dto.DescriptionEn ?? string.Empty

                };

                _context.Set<AboutEntity>().Add(aboutEntity);
            }
            else
            {
                aboutEntity.DescriptionFa = dto.DescriptionFa ?? string.Empty;
                aboutEntity.DescriptionEn = dto.DescriptionEn ?? string.Empty;
                _context.Entry(aboutEntity).State = EntityState.Modified;

            }

            await _context.SaveChangesAsync();
        }

    }
}
