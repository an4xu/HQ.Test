using Binance.Net.Enums;
using StockPrices.Client.Models;
using StockPrices.Models;

namespace StockPrices.Extensions;

public static class IntervalExtensions
{
    internal static Interval ToInterval(this IntervalModel intervalModel)
    { 
        return intervalModel switch
        {
            IntervalModel.Minute => Interval.Minute,
            IntervalModel.Hour => Interval.Hour,
            IntervalModel.Day => Interval.Day,
            _ => throw new ArgumentOutOfRangeException(nameof(intervalModel), intervalModel, null)
        };
    }

    internal static KlineInterval ToBinanceKlineInterval(this Interval interval)
    { 
        return interval switch
        {
            Interval.Minute => KlineInterval.OneMinute,
            Interval.Hour => KlineInterval.OneHour,
            Interval.Day => KlineInterval.OneDay,
            _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
        };
    }

    internal static TimeSpan ToTimeSpan(this Interval interval)
    {
        return interval switch
        {
            Interval.Minute => TimeSpan.FromMinutes(1),
            Interval.Hour => TimeSpan.FromHours(1),
            Interval.Day => TimeSpan.FromDays(1),
            _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
        };
    }
}
