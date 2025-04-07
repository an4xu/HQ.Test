using Arbitrage.Database;
using Arbitrage.Database.Entities;
using Arbitrage.Extensions;
using Arbitrage.Options;
using Calculator.Client;
using Calculator.Client.Models;
using Microsoft.Extensions.Options;
using StockPrices.Client;
using StockPrices.Client.Models;

namespace Arbitrage.Services;

internal class ArbitrageService(IOptions<ArbitrageOptions> options, IStockPricesClient stockPricesClient, ICalculatorClient calculatorClient, ArbitrageContext context, ILogger<ArbitrageService> logger) : IArbitrageService
{
    private readonly ArbitrageOptions options = options.Value;
    private readonly IStockPricesClient stockPricesClient = stockPricesClient;
    private readonly ICalculatorClient calculatorClient = calculatorClient;
    private readonly ArbitrageContext context = context;
    private readonly ILogger<ArbitrageService> logger = logger;

    public async Task CalculateArbitrage(CancellationToken cancellationToken)
    {
        logger.LogInformation("Calculating arbitrage opportunities...");

        var price1 = await stockPricesClient.GetPrice(new GetPriceRequest(options.Symbol1, DateTime.UtcNow, options.Interval.ToModel()));
        var price2 = await stockPricesClient.GetPrice(new GetPriceRequest(options.Symbol2, DateTime.UtcNow, options.Interval.ToModel()));
        var difference = await calculatorClient.CalculateDifference(new CalculateDifferenceRequest(price1.Data.ToCalculatorModel(), price2.Data.ToCalculatorModel()));

        await SaveToDatabase(difference.Data);

        logger.LogInformation("Prices: {price1} - {price2}, Difference: {difference}", price1, price2, difference);
    }

    private async Task SaveToDatabase(PriceDifferenceModel difference)
    {
        context.Add(new PriceDifference()
        {
            Symbol1 = "BTCUSDT_250627",
            Symbol2 = "BTCUSDT_250926",
            Difference = difference.Difference,
        });
        await context.SaveChangesAsync();
    }
}
