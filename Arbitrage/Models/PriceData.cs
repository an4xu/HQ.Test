namespace Arbitrage.Models;

internal record PriceData(PriceDetail Price1, PriceDetail Price2);
internal record PriceDetail(decimal ClosePrice);
