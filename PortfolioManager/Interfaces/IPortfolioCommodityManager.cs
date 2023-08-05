using PortfolioManager.Models;

namespace PortfolioManager.Interfaces
{
    public interface IPortfolioCommodityManager
    {
        IEnumerable<CommodityDto> GetCommodities();
        Task<Dictionary<string, double>> GetCommoditiestWithPrices(IEnumerable<CommodityDto> list);
        void Update(CommodityDto commodityDto);
        void Add(CommodityDto commodityDto);
        bool CommodityExists(int id);
        CommodityDto Find(int? id);
    }
}
