var builder = DistributedApplication.CreateBuilder(args);


var arbitragePostgres = builder.AddPostgres("arbitragePostgres")
    .WithEnvironment("POSTGRES_DB", "arbitragedb")
    .WithPgWeb();
var arbitrageDb = arbitragePostgres.AddDatabase("arbitragedb", "arbitragedb");

var stockPrices = builder.AddProject<Projects.StockPrices>("stockPrices");

var calculator = builder.AddProject<Projects.Calculator>("calculator");


builder.AddProject<Projects.Arbitrage>("arbitrage")
    .WithReference(arbitrageDb)
    .WithReference(stockPrices)
    .WithReference(calculator)
    .WaitFor(arbitrageDb, WaitBehavior.WaitOnResourceUnavailable)
    .WaitFor(stockPrices, WaitBehavior.WaitOnResourceUnavailable)
    .WaitFor(calculator, WaitBehavior.WaitOnResourceUnavailable)
    .WithExternalHttpEndpoints();

builder.Build().Run();
