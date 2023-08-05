using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Managers;
using PortfolioManager.Interfaces;

namespace PortfolioManager.Managers
{
    public class CurrentPriceManager :ICurrentPriceManager
    {
        private readonly IApiPriceManager apiPriceManager;

        public CurrentPriceManager(IApiPriceManager apiPriceManager) => this.apiPriceManager = apiPriceManager;


        public async Task<decimal> GetCurrentPriceAsync(string cryptoName, string currency ="czk" ) 
        {
             return await apiPriceManager.GetActuallPriceAsync(cryptoName,currency);
        }
        public async Task<decimal> GetCurrentPriceAsync()
        {
             return await apiPriceManager.GetActuallPriceAsync();
        }

    }
}
