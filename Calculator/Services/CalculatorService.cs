using Calculator.Models;

namespace Calculator.Services;

internal class CalculatorService : ICalculatorService
{
    public PriceDifference CalculateDifference(Price price1, Price price2)
    {
        var result = price1.High - price2.Low;
        return new PriceDifference(result);
    }
}
