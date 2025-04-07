using HQ.ServiceDefaults;
using StockPrices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddBinance(builder.Configuration.GetSection("Binance"));
builder.Services.AddControllers();
builder.Services.AddScoped<IStockPricesService, BinanceStockPricesService>();

var app = builder.Build();

app.MapControllers();

app.Run();
