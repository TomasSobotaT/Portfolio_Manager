using PortfolioManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Interfaces
{
   
    public interface IHistoricDataManager
    {
        IEnumerable<HistoricDataDto> GetAll();
    }
}
