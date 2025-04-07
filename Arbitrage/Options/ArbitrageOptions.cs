using Arbitrage.Models;

namespace Arbitrage.Options;

internal class ArbitrageOptions
{
    public required string Symbol1 { get; init; }
    public required string Symbol2 { get; init; }
    public required Interval Interval { get; init; }

}
