namespace Arbitrage.Extensions;

public static class PriceModelExtensions
{
    public static Calculator.Client.Models.PriceModel ToCalculatorModel(this StockPrices.Client.Models.PriceModel priceDetailModel)
    {
        return new Calculator.Client.Models.PriceModel(priceDetailModel.Low, priceDetailModel.High);
    }
}
