using Calculator.Client.Models;
using Calculator.Models;

namespace Calculator.Extensions;

public static class PriceDifferenceExtensions
{
    internal static PriceDifferenceModel ToModel(this PriceDifference priceDifference)
    {
        return new PriceDifferenceModel(priceDifference.Difference);
    }
}
