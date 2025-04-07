using Calculator.Client.Models;
using Calculator.Models;

namespace Calculator.Extensions;

public static class PriceExtensions
{
    internal static Price FromModel(this PriceModel priceDetailModel)
    {
        return new Price(priceDetailModel.Low, priceDetailModel.High);
    }
}
