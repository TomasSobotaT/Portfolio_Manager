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

    }
}
