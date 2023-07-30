using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Models;
using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Models;
using PortfolioManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Managers
{
    public class HistoricDataManager : IHistoricDataManager
    {
        private readonly IHistoricDataApiRepository historicDataAPiRepository;
        private readonly IMapper mapper;

        public HistoricDataManager(IHistoricDataApiRepository historicDataAPiRepository, IMapper mapper)
        {
            this.historicDataAPiRepository = historicDataAPiRepository;
            this.mapper = mapper;
        }


        public IEnumerable<HistoricDataDto> GetAll()
        {
            List<HistoricData> historicData = historicDataAPiRepository.GetAll().ToList();
            return mapper.Map<List<HistoricDataDto>>(historicData);
        }


        public HistoricDataDto Get(string name, DateTime date)
        { 
            HistoricData? record = historicDataAPiRepository.Get(name, date);
            return mapper.Map<HistoricDataDto>(record);
        }

    }
}
