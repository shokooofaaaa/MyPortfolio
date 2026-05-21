using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string GithubUrl { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
