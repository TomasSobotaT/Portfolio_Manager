using AutoMapper;
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


        public IEnumerable<CommodityDto> GetCommodities()
        {
            var result = commodityRepository.GetCommodities();

            return mapper.Map<List<CommodityDto>>(result);

        }

        public async Task<Dictionary<string, double>> GetCommoditiestWithPrices(IEnumerable<CommodityDto> list)
        {
            Dictionary<string, double> resultWithCurrentPrices = new();


            foreach (var item in list)
            {
                decimal dPrice = await currentPriceManager.GetCurrentPriceAsync(item.CoingeckoId.Trim().ToLower());
                double price = System.Convert.ToInt32(dPrice);

                resultWithCurrentPrices.Add(item.Name, price * item.Amount);
            }

            return resultWithCurrentPrices;

        }


        public void Update(CommodityDto commodityDto)
        {

            var commodity = mapper.Map<Commodity>(commodityDto);
            commodityRepository.Update(commodity);
        }


        public CommodityDto Find(int? id)
        {
            var result = commodityRepository.Find(id);
            return mapper.Map<CommodityDto>(result);
        }


        public bool CommodityExists(int id) => commodityRepository.CommodityExists(id);


    }
}
