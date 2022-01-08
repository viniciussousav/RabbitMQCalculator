using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.SendCalculation
{
    public interface ISendCalculationUseCase
    {
        public void Execute(SendCalculationRequest request);
    }
}
