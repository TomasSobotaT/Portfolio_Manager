namespace PortfolioManager.Interfaces
{
    public interface ICurrentPriceManager
    {
        Task<decimal> GetCurrentPriceAsync();
        Task<decimal> GetCurrentPriceAsync(string cryptoName, string currency = "czk");
    }
}
