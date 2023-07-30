using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Repositories
{
    public class HistoricDataAPiRepository : BaseApiRepository<HistoricData>, IHistoricDataApiRepository
    {
        public HistoricDataAPiRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public override bool Exists(string name, DateTime date)
        {
            bool result = dbSet.Any(x => (x.Name  == name && x.Date == date));
            return result;
        }

        public override HistoricData Get(string name, DateTime date)
        {

            
            HistoricData? result = base.dbSet
                .Where(x => (x.Name == name && x.Date == date))
                .FirstOrDefault();

          

            return result;
        }

        public override IEnumerable<HistoricData> GetByName(string name)
        {
            return base.dbSet
                .Where(x => (x.Name == name)).ToList();
        }


    }
   
}
