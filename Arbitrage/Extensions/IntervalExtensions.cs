using Arbitrage.Models;
using Hangfire;
using StockPrices.Client.Models;

namespace Arbitrage.Extensions;

public static class IntervalExtensions
{
    internal static IntervalModel ToModel(this Interval interval)
    { 
        return interval switch
        {
            Interval.Minute => IntervalModel.Minute,
            Interval.Hour => IntervalModel.Hour,
            Interval.Day => IntervalModel.Day,
            _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
        };
    }

    internal static string ToCronExpression(this Interval interval)
    { 
        return interval switch
        {
            Interval.Minute => Cron.Minutely(),
            Interval.Hour => Cron.Hourly(),
            Interval.Day => Cron.Daily(),
            _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
        };
    }
}
