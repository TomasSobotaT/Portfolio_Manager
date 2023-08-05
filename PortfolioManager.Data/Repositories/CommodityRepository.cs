using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Identity.Client;
using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Repositories
{
    /// <summary>
    /// provides data about portfolio from database
    /// </summary>
    public class CommodityRepository : ICommodityRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly DbSet<Commodity> commodities;

        public CommodityRepository(ApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
            this.commodities = applicationDbContext.Set<Commodity>();
        
        }


        public  IEnumerable<Commodity> GetCommodities()
        {

          var result =  commodities.ToList();

            return result;
        }

        public  void Update(Commodity commodity)
        {
            commodities.Update(commodity);
            applicationDbContext.SaveChanges();
        }

        public void Add(Commodity commodity)
        {
            commodities.Add(commodity);
            applicationDbContext.SaveChanges();
        }


        public Commodity? Find(int? id) => commodities.Find(id);    
   
        public bool CommodityExists(int id) => commodities.Any(c => c.Id == id);

        
    }
}
