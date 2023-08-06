using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api.Managers;
using PortfolioManager.Interfaces;

namespace PortfolioManager.Managers
{
    public class CurrentPriceManager :ICurrentPriceManager
    {
        private readonly IApiPriceManager apiPriceManager;

        public CurrentPriceManager(IApiPriceManager apiPriceManager) => this.apiPriceManager = apiPriceManager;


        public async Task<decimal> GetCurrentCryptoPriceAsync(string cryptoName, string currency ="czk" ) 
        {
             return await apiPriceManager.GetActuallCryptoPriceAsync(cryptoName,currency);
        }

   

        public async Task<decimal> GetCurrentCryptoPriceAsync()
        {
             return await apiPriceManager.GetActuallCryptoPriceAsync();
        }

        public async Task<decimal?> GetCurrentMetalPriceAsync(string metalName)
        {
            return await apiPriceManager.GetActuallMetalPriceAsync(metalName);
        }

		public async Task<float?> GetCurrentCurrencyPriceAsync(string currencyName)
		{
			return await apiPriceManager.GetActuallCurrencyPriceAsync(currencyName);
		}
	}
}
