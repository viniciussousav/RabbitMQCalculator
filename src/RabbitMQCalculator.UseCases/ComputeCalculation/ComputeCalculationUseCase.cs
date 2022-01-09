using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.Domain.Calculation.Calculation.Repository;
using RabbitMQCalculator.UseCases.SendCalculation.Models;

namespace RabbitMQCalculator.UseCases.ComputeCalculation
{
    public class ComputeCalculationUseCase : IComputeCalculationUseCase
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public ComputeCalculationUseCase(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public async Task<ComputeCalculationResponse> Execute(SendCalculationEvent calculationEvent)
        {
            var calculation = await _calculatorRepository.GetById(calculationEvent.Id);

            try
            {
                var result = GetResult(calculationEvent.FirstNumber, calculationEvent.SecondNumber, calculationEvent.Operation);

                calculation.DefineResult(result);
                await _calculatorRepository.Update(calculation);

                return new ComputeCalculationResponse(calculationEvent.Id, result);
            } 
            catch (Exception ex)
            {
                calculation.SetError(ex.Message);
                await _calculatorRepository.Update(calculation);

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
