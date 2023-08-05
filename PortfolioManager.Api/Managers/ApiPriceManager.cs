using Newtonsoft.Json;
using PortfolioManager.Api.Interfaces;
using PortfolioManager.Api;
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
        private const string metalApiKey = "3667754A97583BBA6F4E8EEC1AE9E24C06DF1C5E";

        public ApiPriceManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// The asynchronous method gets the price of the specified cryptocurrency in the specified currency from coingecko.com API
        /// </summary>
        /// <param name="cryptoName">Name of crypto you want</param>
        /// <param name="currency">Currency in which you want to see the value of cryptos (czk/usd)</param>
        /// <returns>decimal value of crypto price</returns>
        /// <exception cref="Exception"></exception>
        public async Task<decimal> GetActuallCryptoPriceAsync(string cryptoName = "bitcoin", string currency = "czk")
        {

            HttpClient client = _httpClientFactory.CreateClient();

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

        /// <summary>
        /// The asynchronous method gets the price of the specified metal in USD (gold or silver) from api.freegoldprice.org
        /// </summary>
        /// <param name="metalName"> silver / gold</param>
        /// <returns>decimal value of metal price</returns>
        public async Task<decimal?> GetActuallMetalPriceAsync(string metalName)
        {

            HttpClient client = _httpClientFactory.CreateClient();
            
            Uri jsonUrl = new Uri($"https://api.freegoldprice.org/request.cfm?key={metalApiKey}&action=GSJ");

            var response = await client.GetAsync(jsonUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                Metal? result = JsonConvert.DeserializeObject<Metal>(jsonString);

                if (result is null)
                    return 0;

               
                    switch (metalName) 
                {
                    case "gold":
                        return result?.GSJ?.Gold?.USD?.Ask;
                    case "silver":
                        return result?.GSJ?.Silver?.USD?.Ask;
                    default:
                        return 0;
                }
            

            }
            else
            {
                return 0;
            }

        }

    }
}
