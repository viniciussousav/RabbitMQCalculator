using RabbitMQCalculator.UseCases.Shared.Enums;

namespace RabbitMQCalculator.UseCases.Domain.Calculation
{
    public class CalculationEntity
    {
        public CalculationEntity(double firstNumber, double secondNumber, char @operator)
        {
            Guid = Guid.NewGuid();
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operator = @operator;
            Status = CalculationStatus.Pending;
            Error = string.Empty;
        }

        public Guid Guid { get; }
        public double FirstNumber { get; }
        public double SecondNumber { get; }
        public char Operator { get; }
        public double Result { get; private set; }
        public string Error { get; private set; }
        public CalculationStatus Status{ get; private set; }

        public void DefineResult(double result)
        {
            if (Status == CalculationStatus.Pending)
            {
                Result = result;
                Status = CalculationStatus.Success;
            }
        }

        public void SetError(string description)
        {
            if (Status == CalculationStatus.Pending)
            {
                Error = description;
                Status = CalculationStatus.Failed;
            }
        }
    }
}
