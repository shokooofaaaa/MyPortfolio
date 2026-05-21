using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Education
{
  public  interface IEducationService
    {
        Task<PagedListViewModel<EducationViewModel>> GetPagedEducationAsync(int page, int pageSize);

        Task CreateEducationAsync(EducationDto dto);

        Task<EducationDto> GetEducationByIdAsync(Guid id);

        Task UpdateEducationAsync(EducationDto dto);
        Task DeleteEducationAsync(Guid id);

    }
}
