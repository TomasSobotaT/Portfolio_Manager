using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Models;
using System;

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
        /// Get all crypto records
        /// </summary>
        /// <returns>Coollection of all crypto records</returns>
        [HttpGet("crypto")]
        public IActionResult GetAll()
        {
            var result =  historicDataManager.GetAll();
            if (result is null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Get all crypto records with entered name
        /// </summary>
        /// <param name="name">Name of crypto</param>
        /// <returns>Coollection of crypto records with entered name</returns>
        [HttpGet("crypto/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = historicDataManager.GetByName(name);

            if (result is null)
                return NotFound();

            return Ok(result);

        }

        /// <summary>
        /// Get specific record base on name of cryptocurrency and date of record
        /// </summary>
        /// <param name="name">Name of crypto</param>
        /// <param name="date">Date of record</param>
        /// <returns>If found returns status 200 and founded record. If not, returns 404</returns>
        [HttpGet("crypto/{name}/{date}")]
        public IActionResult Get(string name, string date)
        {
            bool validDate = DateTime.TryParse(date, out DateTime dateDatetime);

            if (!validDate)
                return BadRequest();

            var result = historicDataManager.Get(name, dateDatetime);

            if (result is null)
                return NotFound();

            return Ok(result);

        }


        /// <summary>
        /// Add entered cryptocurrency to the database 
        /// </summary>
        /// <param name="record">Crypto record</param>
        /// <returns>Created record</returns>
        [HttpPost("crypto")]
        public IActionResult Add([FromBody] HistoricDataDto record)
        {
            //if(!ModelState.IsValid) 
            //    return BadRequest(ModelState);
            record.Date = DateTime.Now.Date;

            HistoricDataDto? newRecord = historicDataManager.Add(record);
            return CreatedAtAction(nameof(Get), new {name = record.Name, date= record.Date.ToString("dd.MM.yyyy"), id = record.Id}, record);
        }

        /// <summary>
        /// Delete entered record base on name of cryptocurrency and date of record
        /// </summary>
        /// <param name="name">Name of crypto</param>
        /// <param name="date">Date of record</param>
        /// <returns>Deleted record</returns>
        [HttpDelete("crypto/{name}/{date}")]
        public IActionResult Delete(string name, string date)
        {
            bool validDate = DateTime.TryParse(date, out DateTime dateDatetime);

            if (!validDate)
                return BadRequest();

            var result = historicDataManager.Delete(name, dateDatetime);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Update entered record base on name of cryptocurrency and date of record
        /// </summary>
        /// <param name="name">Name of crypto</param>
        /// <param name="date">Date of record</param>
        /// <param name="priceUSD">New price in US dollars</param>
        /// <param name="priceCZK">New price in Czech crowns</param>
        /// <returns>Updated record</returns>
        [HttpPut("crypto/{name}/{date}")]
        public IActionResult Update(string name, string date, decimal priceUSD, decimal priceCZK)
        {
            bool validDate = DateTime.TryParse(date, out DateTime dateDatetime);

            if (!validDate)
                return BadRequest();

            var result = historicDataManager.Update(name, dateDatetime, priceUSD, priceCZK);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
