namespace RabbitMQCalculator.UseCases.Domain.Calculation.Calculation.Repository
{
    public interface ICalculatorRepository
    {
        Task Create(CalculationEntity entity);
        Task<CalculationEntity> GetById(Guid id);
        Task Update(CalculationEntity entity);
    }
}
