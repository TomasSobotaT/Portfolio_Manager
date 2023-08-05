using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Interfaces
{
    public interface ICommodityRepository
    {
        IEnumerable<Commodity> GetCommodities();
        void Update(Commodity commodity);
        bool CommodityExists(int id);
        Commodity? Find(int? id);
        void Add(Commodity commodity);
    }
}
