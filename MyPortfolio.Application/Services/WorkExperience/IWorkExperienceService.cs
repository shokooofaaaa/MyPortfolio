using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.WorkExperience
{
    public interface IWorkExperienceService
    {
        Task<PagedListViewModel<WorkExperienceViewModel>> GetPagedWorkExperienceAsync(int page, int pageSize);

        Task CreateWorkExperienceAsync(WorkExperienceDto dto);

        Task<WorkExperienceDto> GetWorkExperiencetByIdAsync(Guid id);

        Task UpdateWorkExperienceAsync(WorkExperienceDto dto);
        Task DeleteWorkExperienceAsync(Guid id);





    }
}
