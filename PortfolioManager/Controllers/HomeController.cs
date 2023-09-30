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
       
            var priceDollarCzk = await priceManager.GetCurrentCurrencyPriceAsync("usd");
            var priceGoldUsd = await priceManager.GetCurrentMetalPriceAsync("gold");
			ViewBag.PriceUSD = priceDollarCzk.Value.ToString("F2");
            ViewBag.PriceGold = priceGoldUsd.Value.ToString("F0");

			return View();
        }

     

    
    }
}