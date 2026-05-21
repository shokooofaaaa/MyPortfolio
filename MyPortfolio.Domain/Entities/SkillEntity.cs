using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{ 
public class SkillEntity :BaseEntity
    {
        public string Name { get; set; } = default!;
        public int Level { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}
