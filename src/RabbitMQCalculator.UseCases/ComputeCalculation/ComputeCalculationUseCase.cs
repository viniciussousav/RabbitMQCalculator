using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.ComputeCalculation
{
    public class ComputeCalculationUseCase : IComputeCalculationUseCase
    {
        public ComputeCalculationResponse Execute(SendCalculationEvent calculationEvent)
        {
            try
            {
                var result = GetResult(calculationEvent.FirstNumber, calculationEvent.SecondNumber, calculationEvent.Operation);
                return new ComputeCalculationResponse(calculationEvent.Id, result);
            } 
            catch (Exception ex)
            {
                return new ComputeCalculationResponse(calculationEvent.Id, ex.Message);
            }
        }

        private static double GetResult(double firstNumber, double secondNumber, char operation)
        {
            if (operation == '/' && secondNumber == 0)
                throw new ArgumentException("It not possible to divide by 0");

            return operation switch
            {
                '+' => firstNumber + secondNumber,
                '-' => firstNumber - secondNumber,
                '/' => firstNumber / secondNumber,
                '*' => firstNumber * secondNumber,
                _ => throw new NotImplementedException("Error while executing operation")
            };
        }
    }
}
