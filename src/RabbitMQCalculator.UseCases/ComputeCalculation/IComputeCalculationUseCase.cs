using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.ComputeCalculation
{
    public interface IComputeCalculationUseCase
    {
        public ComputeCalculationResponse Execute(SendCalculationEvent calculationEvent);
    }
}
