﻿using AutoMapper;
using PortfolioManager.Api;
using PortfolioManager.Data.Interfaces;
using PortfolioManager.Data.Models;
using PortfolioManager.Interfaces;
using PortfolioManager.Models;

namespace PortfolioManager.Managers
{
    public class PortfolioCommodityManager : IPortfolioCommodityManager
    {

        private readonly IMapper mapper;
        private readonly ICommodityRepository commodityRepository;
        private readonly ICurrentPriceManager currentPriceManager;

        public PortfolioCommodityManager(IMapper mapper, ICommodityRepository commodityRepository, ICurrentPriceManager currentPriceManager)
        {
            this.mapper = mapper;
            this.commodityRepository = commodityRepository;
            this.currentPriceManager = currentPriceManager;
        }


        public  IEnumerable<CommodityDto> GetCommodities(string userId)
        {
        
     
            var result = commodityRepository.GetCommodities(userId);

            return mapper.Map<List<CommodityDto>>(result);

        }

        public async Task<Dictionary<string, double>> GetCommoditiestWithPrices(IEnumerable<CommodityDto> list)
        {
            Dictionary<string, double> resultWithCurrentPrices = new();


            foreach (var item in list)
            {
                decimal? dPrice;        //price from API
                double? dollarPrice = 1; //if dPrice is in USD, get CZK price of dollar an  *

                if (item.Type.ToLower().Trim() == "krypto")
                    dPrice = await currentPriceManager.GetCurrentCryptoPriceAsync(item.ApiId.Trim().ToLower());
                else
                   if (item.Type.ToLower().Trim() == "komodita")
                {
                    dPrice = await currentPriceManager.GetCurrentMetalPriceAsync(item.ApiId.Trim().ToLower());
                    dollarPrice = await currentPriceManager.GetCurrentCurrencyPriceAsync("usd");
                }
                    
                else
                    dPrice = 0;

                double price = System.Convert.ToDouble(dPrice);

                if(dollarPrice is not null && dollarPrice > 1)
                price = price * System.Convert.ToDouble(dollarPrice);

                resultWithCurrentPrices.Add(item.Name, price * item.Amount);
            }

            return resultWithCurrentPrices;

        }


        public void Update(CommodityDto commodityDto)
        {

            var commodity = mapper.Map<Commodity>(commodityDto);
            commodityRepository.Update(commodity);
        }
		public void Delete(int id)
		{
			commodityRepository.Delete(id);
		}

		public void Add(CommodityDto commodityDto)
        {
            var commodity = mapper.Map<Commodity>(commodityDto);
            commodityRepository.Add(commodity);

        }


        public CommodityDto Find(int? id)
        {
            var result = commodityRepository.Find(id);
            return mapper.Map<CommodityDto>(result);
        }


        public bool CommodityExists(int id) => commodityRepository.CommodityExists(id);


    }
}
