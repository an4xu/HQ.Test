
using Microsoft.EntityFrameworkCore;

namespace Arbitrage.Database;

public class MigrationService(IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly IServiceScopeFactory serviceScopeFactory = serviceScopeFactory;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ArbitrageContext>();

        if (!await context.Database.EnsureCreatedAsync(cancellationToken))
        {
            await context.Database.MigrateAsync(cancellationToken);
        }
    }
}
