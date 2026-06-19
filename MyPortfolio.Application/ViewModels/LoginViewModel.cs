using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.EndPoint_UI.Models
{
    public record LoginViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string Username { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
