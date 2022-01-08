using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQCalculator.UseCases.ComputeCalculation.Models;
using RabbitMQCalculator.UseCases.SendCalculation.Models;
using RabbitMQCalculator.UseCases.Shared.Constants;
using System.Text;
using System.Text.Json;

namespace RabbitMQCalculator.UseCases.Shared.Services.CalculationProducer
{
    public class CalculationProducer : ICalculationProducer
    {
        private readonly ConnectionFactory _connectionFactory;

        public CalculationProducer(IConfiguration configuration)
        {
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(configuration.GetConnectionString("RabbitMQ")),
            };
        }

        public void Publish(SendCalculationEvent calculationEvent)
        {
            using var connection = _connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: Topics.CalculationRequest,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var calculationJson = JsonSerializer.Serialize(calculationEvent);
            var calculationBytes = Encoding.UTF8.GetBytes(calculationJson);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: Topics.CalculationRequest,
                basicProperties: null,
                body: calculationBytes);

            connection.Close();
        }

        public void Publish(ComputeCalculationResponse calculationResult)
        {
            using var connection = _connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: Topics.CalculationResult,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var calculationJson = JsonSerializer.Serialize(calculationResult);
            var calculationBytes = Encoding.UTF8.GetBytes(calculationJson);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: Topics.CalculationResult,
                basicProperties: null,
                body: calculationBytes);

            connection.Close();
        }
    }
}
