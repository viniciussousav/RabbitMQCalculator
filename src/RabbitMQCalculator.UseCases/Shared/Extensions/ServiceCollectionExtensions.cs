using Microsoft.Extensions.DependencyInjection;
using RabbitMQCalculator.UseCases.ComputeCalculation;
using RabbitMQCalculator.UseCases.Domain.Calculation.Calculation.Repository;
using RabbitMQCalculator.UseCases.SendCalculation;
using RabbitMQCalculator.UseCases.Shared.Database.Context;
using RabbitMQCalculator.UseCases.Shared.Services.CalculationProducer;

namespace RabbitMQCalculator.UseCases.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICalculationProducer, CalculationProducer>();
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddSingleton<ISendCalculationUseCase, SendCalculationUseCase>();
            services.AddSingleton<IComputeCalculationUseCase, ComputeCalculationUseCase>();
        }

        public static void AddDbContextConfiguration(this IServiceCollection services)
        {
            services.AddDbContextFactory<AppDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICalculatorRepository, CalculatorRepository>();
        }
    }
}
