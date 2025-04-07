using Calculator.Client.Models;
using Refit;

namespace Calculator.Client;

public interface ICalculatorClient
{
    [Post("/api/calculator/difference")]
    Task<CalculateDifferenceResponse> CalculateDifference([Body] CalculateDifferenceRequest request);
}
