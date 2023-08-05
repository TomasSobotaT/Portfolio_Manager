using AutoMapper;
using PortfolioManager.Api.Models;
using PortfolioManager.Data.Models;
using PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api
{
    public class AutomapperConfigurationMain : Profile
    {
        public AutomapperConfigurationMain()
        {
            CreateMap<Commodity, CommodityDto>();
            CreateMap<CommodityDto, Commodity>();
        }
    }
}
