using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Managers;
using System.Diagnostics;

namespace PortfolioManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiPriceManager _priceManager;


        public HomeController(ILogger<HomeController> logger, IApiPriceManager _priceManager)
        {
            _logger = logger;
            this._priceManager = _priceManager;
        }

        public IActionResult Index()
        {
            return View();
        }

     

    
    }
}