using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class ContactMessageEntity:BaseEntity
    {
       
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; } 
    }
}
