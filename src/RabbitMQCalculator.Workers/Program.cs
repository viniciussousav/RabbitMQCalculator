using RabbitMQCalculator.UseCases.Shared.Extensions;
using RabbitMQCalculator.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<CalculatorRequestConsumer>();
        services.AddDbContextConfiguration();
        services.AddServices();
        services.AddUseCases();
        services.AddRepositories();
    })
    .Build();
await host.RunAsync();
