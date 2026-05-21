using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Application.DataTransferObject
{
    public record SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Level { get; set; }
    }
}
