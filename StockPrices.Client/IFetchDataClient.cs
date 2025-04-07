using Refit;
using StockPrices.Client.Models;

namespace StockPrices.Client;

public interface IStockPricesClient
{
    [Get("/api/prices")]
    Task<GetPriceResponse> GetPrice([Query] GetPriceRequest request);
}
