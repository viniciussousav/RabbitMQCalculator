using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.Shared.Services.CalculationProducer
{
    public interface ICalculationProducer
    {
        public void Publish(SendCalculationEvent calculationEvent);
        public void Publish(ComputeCalculationResponse calculationResult);
    }
}
