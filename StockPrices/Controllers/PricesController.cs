using Microsoft.AspNetCore.Mvc;
using StockPrices.Client;
using StockPrices.Client.Models;
using StockPrices.Extensions;
using StockPrices.Services;

namespace StockPrices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PricesController(IStockPricesService stockPricesService) : ControllerBase, IStockPricesClient
{
    private readonly IStockPricesService stockPricesService = stockPricesService;

    [HttpGet]
    public async Task<GetPriceResponse> GetPrice([FromQuery] GetPriceRequest request)
    {
        var price = await stockPricesService.GetPrice(request.Symbol, request.Time, request.Interval.ToInterval());
        return new GetPriceResponse(price.ToModel());
    }
}