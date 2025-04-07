using CryptoExchange.Net.CommonObjects;
using StockPrices.Models;

namespace StockPrices.Services;

public interface IStockPricesService
{
    Task<Price> GetPrice(string symbol, DateTime time, Interval interval);
}
