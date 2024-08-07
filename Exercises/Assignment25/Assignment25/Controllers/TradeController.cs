using Assignment25.Models;
using Assignment25.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment25.Controllers
{
    public class TradeController : Controller
    {
        private readonly FinnhubService _finnhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public TradeController(FinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubService = finnhubService;
            _tradingOptions = tradingOptions;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(_tradingOptions.Value.DefaultStockSymbol))
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";

            Dictionary<string, object>? responseDictionary =  await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            Dictionary<string, object>? stockQuoteDictionary = await _finnhubService.GetCompanyProfile(_tradingOptions.Value.DefaultStockSymbol);

            StockTrade stockTrade = new StockTrade() { StockSymbol = _tradingOptions.Value.DefaultStockSymbol };

            if (_tradingOptions.Value.DefaultStockSymbol != null)
            {
                stockTrade = new StockTrade() {
                    StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                    StockName = Convert.ToString(stockQuoteDictionary["name"]),
                    Price = Convert.ToDouble(responseDictionary["c"].ToString())
                };
            }

            return View(stockTrade);
        }
    }
}
