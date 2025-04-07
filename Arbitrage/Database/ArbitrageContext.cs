using Arbitrage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arbitrage.Database;

public class ArbitrageContext(DbContextOptions<ArbitrageContext> options) : DbContext(options)
{
    DbSet<PriceDifference> PriceDifferences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
