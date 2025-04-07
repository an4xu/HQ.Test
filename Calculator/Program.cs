using Calculator.Services;
using HQ.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.Services.AddScoped<ICalculatorService, CalculatorService>();

var app = builder.Build();

app.MapControllers();

app.Run();
