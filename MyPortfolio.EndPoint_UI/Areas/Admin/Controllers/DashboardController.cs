using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Infrastructure.Context;
using MyPortfolio.Application.ViewModels;
using MyPortfolio.Application.Services.Abouts;
using MyPortfolio.Application.DataTransferObject;

namespace MyPortfolio.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly AppDbContext _context;
     
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            return View(new DashboardViewModel());
        }

        

    }
}
