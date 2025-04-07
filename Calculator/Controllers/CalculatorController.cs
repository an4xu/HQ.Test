using Calculator.Client;
using Calculator.Client.Models;
using Calculator.Extensions;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController(ICalculatorService calculatorService) : ControllerBase, ICalculatorClient
{
    private readonly ICalculatorService calculatorService = calculatorService;

    [HttpPost("difference")]
    public Task<CalculateDifferenceResponse> CalculateDifference([FromBody] CalculateDifferenceRequest request)
    {
        var difference = calculatorService.CalculateDifference(request.Price1.FromModel(), request.Price2.FromModel());
        return Task.FromResult(new CalculateDifferenceResponse(difference.ToModel()));
    }
}