using Microsoft.EntityFrameworkCore;
using RabbitMQCalculator.UseCases.Shared.Database.Context;

namespace RabbitMQCalculator.UseCases.Domain.Calculation.Calculation.Repository
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        public CalculatorRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Create(CalculationEntity entity)
        {
            using var ctx = await _contextFactory.CreateDbContextAsync();
            ctx.Calculations.Add(entity);
        }

        public async Task<CalculationEntity> GetById(Guid id)
        {
            using var ctx = await _contextFactory.CreateDbContextAsync();
            return ctx.Calculations.FirstOrDefault(calculation => calculation.Guid == id);
        }

        public async Task Update(CalculationEntity entity)
        {
            using var ctx = await _contextFactory.CreateDbContextAsync();
            ctx.Update(entity);
        }
    }
}
