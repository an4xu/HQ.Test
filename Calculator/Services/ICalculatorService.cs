using Calculator.Models;

namespace Calculator.Services;

public interface ICalculatorService
{
    PriceDifference CalculateDifference(Price price1, Price price2);
}