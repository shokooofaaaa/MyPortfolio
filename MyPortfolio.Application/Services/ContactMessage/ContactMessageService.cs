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

namespace MyPortfolio.Application.Services.ContactMessage
{
  public  class ContactMessageService : IContactMessageService
    {
        private readonly IContext _context;

        public ContactMessageService(IContext context)
        {
            _context = context;
        }

        public async Task CreateMessageAsync(ContactMessageDto dto)
        {
            var entity = new ContactMessageEntity
            {
               Name = dto.Name,
               Email = dto.Email,
               Message = dto.Message,
               CreatedAt = DateTime.UtcNow


            };

            _context.Set<ContactMessageEntity>().Add(entity);


            await _context.SaveChangesAsync();

        }

        public async Task<PagedListViewModel<ContactMessageViewModel>> GetPagedMessageAsync(int page, int pageSize)
        {

            var query = _context.GetQueryable<ContactMessageEntity>();

            int totalMessages = await query.CountAsync();

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var items = await query
          .OrderByDescending(x => x.CreatedAt)
          .Skip(skip)
          .Take(take)
          .ToListAsync();

            var result = items.Select(x => new ContactMessageViewModel
            {

                Name = x.Name,
                Email = x.Email,
                Message = x.Message

            }).ToList();


            return new PagedListViewModel<ContactMessageViewModel>
            {
                Items = result,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalMessages
            };


        }



    }
    }

