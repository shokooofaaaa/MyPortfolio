using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
   public record ContactMessageViewModel
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

    }
}
