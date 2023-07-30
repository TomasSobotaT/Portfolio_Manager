using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Models;

namespace PortfolioManager.Controllers
{
    [Route("api")]
    [ApiController]
    public class CryptoHistoryController : Controller
    {

        private readonly IHistoricDataManager historicDataManager;

        public CryptoHistoryController(IHistoricDataManager historicDataManager)
        {
            this.historicDataManager = historicDataManager;
        }

        [HttpGet("crypto")]
        public IEnumerable<HistoricDataDto> GetAllHistoricData()
        {
            return historicDataManager.GetAll();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
