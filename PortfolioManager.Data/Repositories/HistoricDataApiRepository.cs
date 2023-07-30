using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Repositories
{
    public class HistoricDataAPiRepository :BaseApiRepository<HistoricData>, IHistoricDataApiRepository
    {
        public HistoricDataAPiRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) { }


        public override HistoricData? Get(string name, DateTime date)
        {
            return base.dbSet
                .Where(x => (x.Date == date && x.Name == name))
                .FirstOrDefault();          
               
        }
    }

   
}
