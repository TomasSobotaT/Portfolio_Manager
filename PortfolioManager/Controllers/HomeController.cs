using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Models;
using System.Diagnostics;

namespace PortfolioManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

     

    
    }
}