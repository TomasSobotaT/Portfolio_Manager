using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Models;

namespace PortfolioManager.Controllers
{
    /// <summary>
    /// Controller for API CRUD methods
    /// </summary>
    [Route("api")]
    [ApiController]
    public class CryptoHistoryController : Controller
    {

        private readonly IHistoricDataManager historicDataManager;

        public CryptoHistoryController(IHistoricDataManager historicDataManager)
        {
            this.historicDataManager = historicDataManager;
        }

        /// <summary>
        /// Get all cryptorecords
        /// </summary>
        /// <returns>All crypto records in database</returns>
        [HttpGet("crypto")]
        public IEnumerable<HistoricDataDto> GetAll()
        {
            return historicDataManager.GetAll();
        }

        /// <summary>
        /// Get specific record base on name of cryptocurrency and date of record
        /// </summary>
        /// <param name="name">Name of crypto</param>
        /// <param name="dateString">Date of record</param>
        /// <returns>If found returns status 200 and founded record, if not returns 404</returns>
        [HttpGet("crypto/{name}/{dateString}")] //https://localhost:7169/api/crypto/bitcoin/2023-01-01
        public IActionResult Get(string name, string dateString)
        {
            DateTime.TryParse(dateString, out DateTime date);

            var result = historicDataManager.Get(name, date);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
    }
}
