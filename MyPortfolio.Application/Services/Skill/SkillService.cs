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

namespace MyPortfolio.Application.Services.Skill
{
   public class SkillService:ISkillService
    {

        private readonly IContext _context;

        public SkillService(IContext context)
        {
            _context = context;
        }

        public async Task CreateSkillAsync(SkillDto dto)
        {
            if(dto == null)
            {
                throw new Exception("فرم خالی است ");
            }
            else
            {
                var skillEntity = new SkillEntity
                {
                    Name=dto.Name,
                    Level=dto.Level
                };

                _context.Set<SkillEntity>().Add(skillEntity);

                await _context.SaveChangesAsync();

            }

        }

        public async Task DeleteSkillAsync(Guid SkillId)
        {
            SkillEntity? entity =
               await _context.Set<SkillEntity>()
               .FirstOrDefaultAsync(f => f.Id == SkillId);

            if (entity == null)
            {
                throw new Exception("مهارتی با این شناسه یافت نشد.");
            }
            entity.IsDelete = true;
            _context.Set<SkillEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedListViewModel<SkillViewModel>> GetPagedSkillsAsync(int page, int pageSize)
        {
            var query = _context.GetQueryable<SkillEntity>().Where(p=>!p.IsDelete);

            int totalSkills = await query.CountAsync();

            var skip = (page - 1) * pageSize;

            var take = pageSize;

            var items = await query.OrderByDescending(x => x.Id)
                .Skip(skip).Take(take).Select(x => new SkillViewModel

                {    Id=x.Id,
                    Name = x.Name,
                    Level = x.Level


                }

                ).ToListAsync();

            return new PagedListViewModel<SkillViewModel>
            {
                Items = items,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalSkills
            };

        }

        public async Task<SkillViewModel> GetSkillById(Guid Id)
        {
            var skill= await _context.Set<SkillEntity>().FindAsync(Id);

            if (skill == null)

                return null;

            var skillModel = new SkillViewModel
            {
                Id=skill.Id,
                Name=skill.Name,
                Level = skill.Level


            };
            return skillModel;

        }

        public async Task UpdateSkillAsync(SkillDto dto)
        {
            var skill = await _context.Set<SkillEntity>().FindAsync(dto.Id);

            if (skill == null)
                throw new Exception();

            skill.Name = dto.Name;
            skill.Level = dto.Level;

            await _context.SaveChangesAsync();

        }
    }
}
