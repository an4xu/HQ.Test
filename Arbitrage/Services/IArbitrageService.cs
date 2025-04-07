namespace Arbitrage.Services;

public interface IArbitrageService
{
    Task CalculateArbitrage(CancellationToken cancellationToken);
}
