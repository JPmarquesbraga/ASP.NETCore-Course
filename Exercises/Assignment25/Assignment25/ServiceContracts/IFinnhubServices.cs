namespace Assignment25.ServiceContracts
{
    public interface IFinnhubServices
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);

        Task<Dictionary<string , object>> GetCompanyProfile(string stockSymbol);
    }
}
