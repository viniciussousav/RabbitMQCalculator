namespace RabbitMQCalculator.UseCases.ComputeCalculation.Models
{
    public class ComputeCalculationResponse
    {
        public ComputeCalculationResponse(Guid id, double result)
        {
            Id = id;
            Result = result;
        }

        public ComputeCalculationResponse(Guid id, string error)
        {
            Id = id;
            Error = error;
        }

        public Guid Id { get; }
        public double? Result { get; }
        public string Error { get; }
    }
}
