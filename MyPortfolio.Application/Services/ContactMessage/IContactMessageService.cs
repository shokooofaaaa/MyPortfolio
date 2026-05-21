using MyPortfolio.Application.DataTransferObject;
using MyPortfolio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.Services.ContactMessage
{
    public interface IContactMessageService
    {
        Task CreateMessageAsync(ContactMessageDto dto);

        Task<PagedListViewModel<ContactMessageViewModel>> GetPagedMessageAsync(int page, int pageSize);


      
    }
}
