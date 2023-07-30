using PortfolioManager.Api.Models;
using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Interfaces
{
   
    public interface IHistoricDataManager
    {
        HistoricDataDto Get(string name, DateTime date);
        IEnumerable<HistoricDataDto> GetAll();
    }
}
