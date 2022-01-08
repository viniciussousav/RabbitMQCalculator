using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQCalculator.UseCases.ComputeCalculation;
using RabbitMQCalculator.UseCases.SendCalculation.Models;
using RabbitMQCalculator.UseCases.Shared.Constants;
using RabbitMQCalculator.UseCases.Shared.Services.CalculationProducer;
using System.Text;
using System.Text.Json;

namespace RabbitMQCalculator.Workers
{
    public class CalculatorRequestConsumer : BackgroundService
    {
        private readonly ILogger<CalculatorRequestConsumer> _logger;
        private readonly IComputeCalculationUseCase _computeCalculationUseCase;
        private readonly ICalculationProducer _calculationProducer;

        private readonly IConnection _connection;
        private readonly IModel _channel;

        public CalculatorRequestConsumer(
            ILogger<CalculatorRequestConsumer> logger,
            IComputeCalculationUseCase computeCalculationUseCase,
            ICalculationProducer calculationProducer,
            IConfiguration configuration)
        {
            _logger = logger;
            _computeCalculationUseCase = computeCalculationUseCase;
            _calculationProducer = calculationProducer;

            var factory = new ConnectionFactory
            {
                Uri = new Uri(configuration.GetConnectionString("RabbitMQ"))
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: Topics.CalculationRequest,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueDeclare(
                queue: Topics.CalculationResult,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _logger.LogInformation("ExecuteAsync started at {DateTime}", DateTime.Now);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, eventArgs) =>
            {
                try
                {
                    var bodyBytes = eventArgs.Body.ToArray();
                    var eventJson = Encoding.UTF8.GetString(bodyBytes);

                    var eventRequest = JsonSerializer.Deserialize<SendCalculationEvent>(eventJson);

                    _logger.LogInformation("Request with Id = {Id} received at {DateTime}", eventRequest?.Id, DateTime.Now);
                    _channel.BasicAck(eventArgs.DeliveryTag, false);

                    var result = _computeCalculationUseCase.Execute(eventRequest!);
                    _calculationProducer.Publish(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while consuming message: {Message}", ex.Message);
                }
            };

            _channel.BasicConsume(Topics.CalculationRequest, false, consumer);
            return Task.CompletedTask;
        }
    }
}