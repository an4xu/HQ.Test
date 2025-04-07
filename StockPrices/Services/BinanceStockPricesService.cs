using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using StockPrices.Extensions;
using StockPrices.Models;

namespace StockPrices.Services;

internal class BinanceStockPricesService(IBinanceRestClient client) : IStockPricesService
{
    private readonly IBinanceRestClient client = client;

    public async Task<Price> GetPrice(string symbol, DateTime time, Interval interval)
    {
        var binanceKline = await GetPriceFromBinance(symbol, time, interval);

        return binanceKline.ToPriceData();
    }

    private async Task<IBinanceKline> GetPriceFromBinance(string symbol, DateTime time, Interval interval)
    {
        var result = await client.UsdFuturesApi.ExchangeData.GetKlinesAsync(symbol, 
            interval.ToBinanceKlineInterval(), 
            startTime: time - interval.ToTimeSpan(),
            endTime: time);

        if (!result.HasData())
        {
            foreach (var span in GetIntervalTimeSpans(interval))
            {
                var lastAvailableResult = await client.UsdFuturesApi.ExchangeData.GetKlinesAsync(
                    symbol,
                    interval.ToBinanceKlineInterval(),
                    startTime: time - span,
                    endTime: time
                );

                if (result.HasData())
                {
                    return lastAvailableResult.Data.Last();
                }
            }

            throw new Exception($"No data available for symbol {symbol}");
        }

        return result.Data.Last();
    }

    private static TimeSpan[] GetIntervalTimeSpans(Interval interval)
    {
        TimeSpan[] result = interval switch
        {
            Interval.Minute => [TimeSpan.FromHours(1), TimeSpan.FromDays(1), TimeSpan.FromDays(30), TimeSpan.FromDays(365)],
            Interval.Hour => [TimeSpan.FromDays(1), TimeSpan.FromDays(30), TimeSpan.FromDays(365)],
            Interval.Day => [TimeSpan.FromDays(30), TimeSpan.FromDays(365)],
            _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
        };

        return result;
    }
}