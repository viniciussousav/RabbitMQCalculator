namespace RabbitMQCalculator.UseCases.SendCalculation.Models
{
    public static class SendCalculationRequestMapper
    {
        public static SendCalculationEvent MapToEvent(this SendCalculationRequest request)
            => new(request.FirstNumber, request.SecondNumber, request.Operation);
    }
}
