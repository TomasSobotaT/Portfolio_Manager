//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PortfolioManager.Data;
//using PortfolioManager.Data.Models;

//namespace PortfolioManager.Controllers
//{
//    /// <summary>
//    /// Controller for actual portfolio value
//    /// </summary>
//    public class PortfolioController : Controller
//    {
//        //private readonly PortfolioManagerContext _context;

//        public PortfolioController()
//        {
     
//        }

//        // GET: Commodities
//        public async Task<IActionResult> Index()
//        {
//              return _context.Commodity != null ? 
//                          View(await _context.Commodity.ToListAsync()) :
//                          Problem("Entity set 'PortfolioManagerContext.Commodity'  is null.");
//        }

//        // GET: Commodities/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Commodity == null)
//            {
//                return NotFound();
//            }

//            var commodity = await _context.Commodity
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (commodity == null)
//            {
//                return NotFound();
//            }

//            return View(commodity);
//        }

//        // GET: Commodities/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Commodities/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Amount,InvestedMoney")] Commodity commodity)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(commodity);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(commodity);
//        }

//        // GET: Commodities/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Commodity == null)
//            {
//                return NotFound();
//            }

//            var commodity = await _context.Commodity.FindAsync(id);
//            if (commodity == null)
//            {
//                return NotFound();
//            }
//            return View(commodity);
//        }

//        // POST: Commodities/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,InvestedMoney")] Commodity commodity)
//        {
//            if (id != commodity.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(commodity);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CommodityExists(commodity.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(commodity);
//        }

//        // GET: Commodities/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Commodity == null)
//            {
//                return NotFound();
//            }

//            var commodity = await _context.Commodity
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (commodity == null)
//            {
//                return NotFound();
//            }

//            return View(commodity);
//        }

//        // POST: Commodities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Commodity == null)
//            {
//                return Problem("Entity set 'PortfolioManagerContext.Commodity'  is null.");
//            }
//            var commodity = await _context.Commodity.FindAsync(id);
//            if (commodity != null)
//            {
//                _context.Commodity.Remove(commodity);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CommodityExists(int id)
//        {
//          return (_context.Commodity?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
