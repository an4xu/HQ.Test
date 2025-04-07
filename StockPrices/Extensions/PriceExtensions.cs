using StockPrices.Client.Models;
using StockPrices.Models;

namespace StockPrices.Extensions;

public static class PriceExtensions
{
    internal static PriceModel ToModel(this Price priceData)
    {
        return new PriceModel(priceData.Low, priceData.High);
    }
}
