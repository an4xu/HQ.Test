namespace StockPrices.Client.Models;

public record GetPriceRequest(string Symbol, DateTime Time, IntervalModel Interval);
