using AutoMapper;
using PortfolioManager.Api.Models;
using PortfolioManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<HistoricData, HistoricDataDto>();
            CreateMap<HistoricDataDto, HistoricData>();
        }
    }
}
