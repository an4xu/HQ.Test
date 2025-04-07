using Binance.Net.Interfaces;
using CryptoExchange.Net.Objects;
using StockPrices.Models;

namespace StockPrices.Extensions;

public static class BinanceExtensions
{
    internal static Price ToPriceData(this IBinanceKline binanceKline)
    {
        return new Price(binanceKline.LowPrice, binanceKline.HighPrice);
    }

    internal static bool HasData(this WebCallResult<IEnumerable<IBinanceKline>> response)
    {
        return response.Success && response.Data != null && response.Data.Any();
    }
}
