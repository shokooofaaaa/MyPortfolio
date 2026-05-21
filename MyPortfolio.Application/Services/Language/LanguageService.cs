using Application.Common.Extension;
using Application.Contract;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Language
{
  public  class LanguageService : ILanguageService
    {
        private readonly IContext _context;

        public LanguageService(IContext context)
        {
            _context = context;
        }

        public async Task CreateLanguageAsync(LanguageDto dto)
        {
            if (dto == null)
            {
                throw new Exception("فرم خالی است ");
            }
            else
            {
                var LanguageEntity = new LanguageEntity
                {
                    Name = dto.Name,
                    Level = dto.Level
                };

                _context.Set<LanguageEntity>().Add(LanguageEntity);

                await _context.SaveChangesAsync();

            }
        }

        public async Task DeleteLanguageAsync(Guid id)
        {
            LanguageEntity? entity =
              await _context.Set<LanguageEntity>()
              .FirstOrDefaultAsync(f => f.Id == id);

            if (entity == null)
            {
                throw new Exception("مهارتی با این شناسه یافت نشد.");
            }
            entity.IsDelete = true;
            _context.Set<LanguageEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<LanguageDto> GetLanguageById(Guid Id)
        {
            var language = await _context.Set<LanguageEntity>().FindAsync(Id);

            if (language == null)

                return null;

            var languageDto = new LanguageDto
            {
                Id = language.Id,
                Name = language.Name,
                Level = language.Level


            };
            return languageDto;
        }

        public async Task<PagedListViewModel<LanguageViewModel>> GetPagedLanguageAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<LanguageEntity>().Where(x => !x.IsDelete);

            int totalLanguages = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var items = await query
          .OrderByDescending(x => x.Id)
          .Skip(skip)
          .Take(take)
          .ToListAsync();

            var result = items.Select(x => new LanguageViewModel
            {
                Id = x.Id,
                Name=x.Name,
                Level = x.Level
            }).ToList();

            return new PagedListViewModel<LanguageViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalLanguages
            };
        }

        public async Task UpdateLanguageAsync(LanguageDto dto)
        {
            var language = await _context.Set<LanguageEntity>().FindAsync(dto.Id);

            if (language == null)
                throw new Exception("زیانی با این شناسه یافت نشد");

            language.Name = dto.Name;
            language.Level = dto.Level;
          

            await _context.SaveChangesAsync();
        }
    }
}
