using Microsoft.AspNetCore.Mvc;
using RabbitMQCalculator.UseCases.SendCalculation;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("calculation")]
    public class CalculationController : ControllerBase
    {
        private readonly ILogger<CalculationController> _logger;
        private readonly ISendCalculationUseCase _sendCalculationUseCase;

        public CalculationController(ILogger<CalculationController> logger, ISendCalculationUseCase sendCalculationUseCase)
        {
            _logger = logger;
            _sendCalculationUseCase = sendCalculationUseCase;
        }

        [HttpPost("send")]
        public IActionResult SendCalculation([FromBody] SendCalculationRequest request)
        {
            _logger.LogInformation("{SendCalculation} requested at {Datime}", nameof(SendCalculation), DateTime.Now);
            _sendCalculationUseCase.Execute(request);
            return Ok();
        }
    }
}