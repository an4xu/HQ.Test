using Arbitrage.Database;
using Arbitrage.Jobs;
using Arbitrage.Options;
using Arbitrage.Services;
using Calculator.Client;
using Hangfire;
using Hangfire.PostgreSql;
using HQ.ServiceDefaults;
using Refit;
using StockPrices.Client;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(postgresConfig =>
    {
        postgresConfig.UseNpgsqlConnection(builder.Configuration.GetConnectionString("arbitragedb"));
    });
});
builder.Services.AddHangfireServer();

builder.Services.AddHostedService<MigrationService>();
builder.Services.AddHostedService<ArbitrageJob>();
builder.Services.AddScoped<IArbitrageService, ArbitrageService>();
builder.Services.Configure<ArbitrageOptions>(builder.Configuration.GetSection(nameof(ArbitrageOptions)));

builder.Services.AddRefitClient<IStockPricesClient>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https+http://stockPrices");
});
builder.Services.AddRefitClient<ICalculatorClient>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https+http://calculator");
});

builder.AddNpgsqlDbContext<ArbitrageContext>("arbitragedb");

var app = builder.Build();
app.MapDefaultEndpoints();
app.Run();
