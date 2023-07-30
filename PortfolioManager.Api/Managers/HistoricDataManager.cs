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
            List<HistoricData> result = historicDataAPiRepository.GetAll().ToList();
            return mapper.Map<List<HistoricDataDto>>(result);
        }

        public HistoricDataDto Get(string name, DateTime date)
        { 
            HistoricData? result = historicDataAPiRepository.Get(name, date);
            return mapper.Map<HistoricDataDto>(result);
        }

        public IEnumerable<HistoricDataDto> GetByName(string name)
        {
            List <HistoricData> result = historicDataAPiRepository.GetByName(name).ToList();
            return mapper.Map<List<HistoricDataDto>>(result);
        }

        public HistoricDataDto? Add(HistoricDataDto record)
        {
            var result = mapper.Map<HistoricData>(record);
            result.Id = default;
            HistoricData? newRecord = historicDataAPiRepository.Insert(result);

            return mapper.Map<HistoricDataDto>(newRecord);
        }

        public HistoricDataDto? Delete(string name,DateTime date)
        {

            if (!historicDataAPiRepository.Exists(name, date))
                return null;

            HistoricData? deleteRecord = historicDataAPiRepository.Get(name,date);

            HistoricDataDto? response = mapper.Map<HistoricDataDto>(deleteRecord);

            if (deleteRecord is not null)
                historicDataAPiRepository.Delete(deleteRecord);
            else
                return null;

            return response;
        }

        public HistoricDataDto? Update(string name, DateTime date, decimal priceUSD, decimal priceCZK)
        {

            if (!historicDataAPiRepository.Exists(name, date))
                return null;

            HistoricData? updateRecord = historicDataAPiRepository.Get(name, date);

            if (updateRecord is null)
                return null;
     
            updateRecord.PriceUSD = priceUSD;
            updateRecord.PriceCZK = priceCZK;

            HistoricData? response = historicDataAPiRepository.Update(updateRecord);

            return mapper.Map<HistoricDataDto>(response);
        }

    }
}
