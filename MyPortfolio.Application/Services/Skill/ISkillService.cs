using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Skill
{
    public interface ISkillService
    {
        Task CreateSkillAsync(SkillDto dto);
        Task<PagedListViewModel<SkillViewModel>> GetPagedSkillsAsync(int page, int pageSize);
        Task<SkillViewModel> GetSkillById(Guid Id);

        Task UpdateSkillAsync(SkillDto dto);

        Task DeleteSkillAsync(Guid id);


    }
}
