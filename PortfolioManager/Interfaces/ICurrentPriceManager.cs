namespace PortfolioManager.Interfaces
{
    public interface ICurrentPriceManager
    {
        Task<decimal> GetCurrentCryptoPriceAsync();
        Task<decimal> GetCurrentCryptoPriceAsync(string cryptoName, string currency = "czk");
		Task<float?> GetCurrentCurrencyPriceAsync(string currencylName);
		Task<decimal?> GetCurrentMetalPriceAsync(string metalName);
    }
}
