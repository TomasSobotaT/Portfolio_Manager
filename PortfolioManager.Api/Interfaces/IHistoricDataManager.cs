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
        HistoricDataDto? Get(string name, DateTime date);
        IEnumerable<HistoricDataDto> GetByName(string name);
        IEnumerable<HistoricDataDto> GetAll();
        HistoricDataDto? Add(HistoricDataDto record);
        HistoricDataDto? Delete(string name, DateTime date);
        HistoricDataDto? Update(string name, DateTime date, decimal priceUSD, decimal priceCZK);
    }
}
