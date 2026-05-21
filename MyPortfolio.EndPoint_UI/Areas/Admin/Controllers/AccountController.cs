using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Infrastructure.Context;
using MyPortfolio.EndPoint_UI.Models;
using System.Security.Claims;
using MyPortfolio.Application.DataTransferObject;
namespace MyPortfolio.EndPoint_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private const string _username = "admin";
        private const string _password = "12345";
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto) 
        {
            if (loginDto.Username == _username && loginDto.Password == _password)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.Username)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.ErrorMessage = "یوزرنیم یا پسورد اشتباه است.";
            return View(loginDto);
        }
    }


}
