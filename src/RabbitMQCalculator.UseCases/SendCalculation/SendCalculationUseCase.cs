using Microsoft.Extensions.Logging;
using RabbitMQCalculator.UseCases.Domain.Calculation;
using RabbitMQCalculator.UseCases.Domain.Calculation.Calculation.Repository;
using RabbitMQCalculator.UseCases.SendCalculation.Models;
using RabbitMQCalculator.UseCases.Shared.Services.CalculationProducer;

namespace RabbitMQCalculator.UseCases.SendCalculation
{
    public class SendCalculationUseCase : ISendCalculationUseCase
    {
        private readonly ILogger<SendCalculationUseCase> _logger;
        private readonly ICalculatorRepository _calculatorRepository;
        private readonly ICalculationProducer _calculationProducer;

        public SendCalculationUseCase(
            ILogger<SendCalculationUseCase> logger,
            ICalculationProducer calculationProducer, 
            ICalculatorRepository calculatorRepository)
        {
            _logger = logger;
            _calculationProducer = calculationProducer;
            _calculatorRepository = calculatorRepository;
        }

        public async void Execute(SendCalculationRequest request)
        {
            _logger.LogInformation("Executing calculation request at {DateTime}", DateTime.Now);

            var calculationEvent = request.MapToEvent();
            _calculationProducer.Publish(calculationEvent);

            _logger.LogInformation("Calculation request published at {DateTime}", DateTime.Now);
        }
    }
}
