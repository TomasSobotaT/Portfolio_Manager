using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Interfaces
{
    public interface IApiPriceManager
    {
        Task<decimal> GetActuallCryptoPriceAsync(string cryptoName = "bitcoin", string currency = "czk");
		Task<float?> GetActuallCurrencyPriceAsync(string currencyName = "usd");
		Task<decimal?> GetActuallMetalPriceAsync(string metalName);
    }
}
