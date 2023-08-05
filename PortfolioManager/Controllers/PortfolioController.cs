using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Data;
using PortfolioManager.Data.Models;
using PortfolioManager.Interfaces;
using PortfolioManager.Managers;
using PortfolioManager.Models;

namespace PortfolioManager.Controllers
{
    /// <summary>
    /// Controller for actual portfolio value
    /// </summary>
    public class PortfolioController : Controller
    {
        private readonly IPortfolioCommodityManager portfolioCommodityManager;



        public PortfolioController(IPortfolioCommodityManager portfolioCommodityManager)
        {
            this.portfolioCommodityManager = portfolioCommodityManager;

        }

        public async Task<IActionResult> Index()
        {
            var result = portfolioCommodityManager.GetCommodities();

            if (result is null)
                return Problem("Commodity is null.");


            Dictionary<string, double> resultWithCurrentPrices 
                =  await portfolioCommodityManager.GetCommoditiestWithPrices(result);
                
                 ViewBag.CurrentPrices = resultWithCurrentPrices;

                return View(result);

        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            
            var commodity =  portfolioCommodityManager.Find(id);
            if (commodity == null)
            {
                return NotFound();
            }
            return View(commodity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Type,CoingeckoId,Amount,InvestedMoney")] CommodityDto commodity)
        {
            if (id != commodity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    portfolioCommodityManager.Update(commodity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommodityExists(commodity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(commodity);
        }



        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Type,CoingeckoId,Amount,InvestedMoney")] CommodityDto commodity)
        {
            if (ModelState.IsValid)
            {
                portfolioCommodityManager.Add(commodity);
                return RedirectToAction(nameof(Index));
            }
            return View(commodity);
        }





        #region HelpMethods

        private bool CommodityExists(int id)
        {
            return portfolioCommodityManager.CommodityExists(id);
        }

        #endregion
    }
}
