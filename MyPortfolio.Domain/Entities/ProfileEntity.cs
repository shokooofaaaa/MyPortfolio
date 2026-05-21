using Domain.Entities;

namespace MyPortfolio.Domain.Entities
{
    public class ProfileEntity: BaseEntity
    {
        public string FullNameEn { get; set; }
        public string FullNameFa { get; set; }

        public string JobTitleEn { get; set; } 
        public string JobTitleFa { get; set; } 

        public string ProfileImagePath { get; set; } 



    }
}
