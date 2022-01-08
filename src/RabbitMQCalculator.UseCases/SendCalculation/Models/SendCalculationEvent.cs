namespace RabbitMQCalculator.UseCases.SendCalculation.Models
{
    public class SendCalculationEvent
    {
        public SendCalculationEvent(double firstNumber, double secondNumber, char operation)
        {
            Id = Guid.NewGuid();
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
        }

        public Guid Id { get; }
        public double FirstNumber { get; }
        public double SecondNumber { get; }
        public char Operation { get; }
    }
}
