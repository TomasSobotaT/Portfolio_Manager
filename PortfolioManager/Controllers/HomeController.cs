using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Managers;
using PortfolioManager.Interfaces;
using System.Diagnostics;

namespace PortfolioManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrentPriceManager priceManager;


        public HomeController(ILogger<HomeController> logger, ICurrentPriceManager priceManager)
        {
            _logger = logger;
            this.priceManager = priceManager;
        }

        public async Task<IActionResult> Index()
        {
            //ViewBag.PriceUSD = await priceManager.GetCurrentCurrencyPriceAsync("usd");
                
            return View();
        }

     

    
    }
}