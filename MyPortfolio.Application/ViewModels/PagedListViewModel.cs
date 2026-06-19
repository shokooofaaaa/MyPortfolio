using System;
using System.Collections.Generic;

namespace MyPortfolio.Application.ViewModels
{
    public record PagedListViewModel<T>
    {
        public List<T> Items { get; set; } = new();

        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int PageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

      
    }
}
