using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;

namespace MyPortfolio.Application.Services
{
    public interface IProjectService
    {


        Task<PagedListViewModel<ProjectViewModel> >GetPagedProjectsAsync(int page, int pageSize);

        Task CreateProjectAsync(ProjectDto dto);

        Task<ProjectDto> GetProjectByIdAsync(Guid id);

        Task UpdateProjectAsync(ProjectDto dto);
        Task DeleteProjectAsync(Guid id);
    }
}
