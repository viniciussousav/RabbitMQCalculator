namespace RabbitMQCalculator.UseCases.SendCalculation.Models
{
    public class SendCalculationRequest
    {
        public SendCalculationRequest(double firstNumber, double secondNumber, char operation)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
        }

        public double FirstNumber { get; }
        public double SecondNumber { get; }
        public char Operation { get; }
    }
}
