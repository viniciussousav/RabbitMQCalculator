using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.ComputeCalculation
{
    public interface IComputeCalculationUseCase
    {
        public Task<ComputeCalculationResponse> Execute(SendCalculationEvent calculationEvent);
    }
}
