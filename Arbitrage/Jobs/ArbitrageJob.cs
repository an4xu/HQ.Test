using Arbitrage.Extensions;
using Arbitrage.Options;
using Arbitrage.Services;
using Hangfire;
using Microsoft.Extensions.Options;

namespace Arbitrage.Jobs;

internal class ArbitrageJob(IOptions<ArbitrageOptions> options, IRecurringJobManager recurringJobManager) : BackgroundService
{
    private readonly ArbitrageOptions options = options.Value;
    private readonly IRecurringJobManager recurringJobManager = recurringJobManager;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        recurringJobManager.AddOrUpdate<IArbitrageService>(
            "ArbitrageJob",
            service => service.CalculateArbitrage(stoppingToken),
            options.Interval.ToCronExpression());
        return Task.CompletedTask;
    }
}
