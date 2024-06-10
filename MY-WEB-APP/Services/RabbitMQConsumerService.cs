using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MY_WEB_APP.Models;
using MY_WEB_APP.Services;

namespace MY_WEB_APP.Services
{
    public class RabbitMQConsumerService : BackgroundService
    {
        private readonly ILogger<RabbitMQConsumerService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection;
        private IChannel _channel;

        public RabbitMQConsumerService(ILogger<RabbitMQConsumerService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        private async Task InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; // Use your RabbitMQ server hostname
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(queue: "raw_data_queue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            _logger.LogInformation("RabbitMQ connection established and queue declared.");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            await InitializeRabbitMQ();

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"Received message: {message}");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();

                    try
                    {
                        var rawData = JsonConvert.DeserializeObject<RawData>(message);
                        await dataService.TransformAndSaveDataAsync(rawData);
                        _logger.LogInformation("Message processed successfully.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Message processing failed: {ex.Message}");
                    }
                }
            };

            await _channel.BasicConsumeAsync(queue: "raw_data_queue",
                                  autoAck: false,
                                  consumer: consumer);

            await Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }
    }
}
