using Newtonsoft.Json;
using PortfolioManager.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace PortfolioManager.Api.Managers
{
    /// <summary>
    /// Get current commodity prices from API
    /// </summary>
    public class ApiPriceManager : IApiPriceManager
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ApiPriceManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// The asynchronous method gets the price of the specified cryptocurrency in the specified currency
        /// </summary>
        /// <param name="cryptoName">Name of crypto you want</param>
        /// <param name="currency">Currency in which you want to see the value of cryptos (czk/usd)</param>
        /// <returns>decimal value of crypto price</returns>
        /// <exception cref="Exception"></exception>
        public async Task<decimal> GetActuallPriceAsync(string cryptoName = "bitcoin", string currency = "czk")
        {

            using HttpClient client = _httpClientFactory.CreateClient();

            Uri jsonUrl = new Uri($"https://api.coingecko.com/api/v3/simple/price?ids={cryptoName.ToLower().Trim()}&vs_currencies={currency.ToLower().Trim()}");

            var response = await client.GetAsync(jsonUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dictionary<string, Crypto>>(jsonString);

                if (result is null || result.Count == 0)
                    return 0;


                if (currency.Equals("usd",StringComparison.OrdinalIgnoreCase))
                    return result.First().Value.usd;

                return result.First().Value.czk;

            }
            else
            {
                return 0;
            }

        }



    }
}
