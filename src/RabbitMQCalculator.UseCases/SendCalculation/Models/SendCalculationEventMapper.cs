using RabbitMQCalculator.UseCases.Domain.Calculation;

namespace RabbitMQCalculator.UseCases.SendCalculation.Models
{
    public static class SendCalculationEventMapper
    {
        public static CalculationEntity MapToCalculation(this SendCalculationEvent calculationEvent)
            => new (calculationEvent.FirstNumber, calculationEvent.SecondNumber, calculationEvent.Operation);
    }
}
