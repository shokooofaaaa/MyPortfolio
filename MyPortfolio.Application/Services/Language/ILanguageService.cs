using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.Language
{
    public interface ILanguageService
    {


        Task CreateLanguageAsync(LanguageDto dto);
        Task<PagedListViewModel<LanguageViewModel>> GetPagedLanguageAsync(int page, int pageSize);
        Task<LanguageDto> GetLanguageById(Guid Id);

        Task UpdateLanguageAsync(LanguageDto dto);

        Task DeleteLanguageAsync(Guid id);
    }
}
