using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.EndPoint_UI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
