using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using QIQO.MQ;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Background
{
    public class AccountAddConsumerService : BackgroundServiceBase
    {
        private readonly ILogger<AccountAddConsumerService> _log;
        private readonly IConfiguration _configuration;
        private ConnectionFactory _factory;
        private IConnection _connection;

        public AccountAddConsumerService(ILogger<AccountAddConsumerService> logger, IConfiguration configuration)
        {
            _log = logger;
            _configuration = configuration;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug("AccountConsumerService -> ExecuteAsync started");
            stoppingToken.Register(() => _log.LogDebug($"AccountConsumerService background task is stopping."));

            var hostName = _configuration["QueueConfig:Server"];
            var userName = _configuration["QueueConfig:User"];
            var password = _configuration["QueueConfig:Password"];
            var exchangeName = _configuration["QueueConfig:Account:Exchange"];
            var queueName = _configuration["QueueConfig:Account:PublishAddQueueName"];
            var routingKey = _configuration["QueueConfig:Account:PublishAddQueueName"];

            _factory = new ConnectionFactory { HostName = hostName, UserName = userName, Password = password };
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, "topic");
                    channel.QueueDeclare(queueName, true, false, false, null);
                    channel.QueueBind(queueName, exchangeName, routingKey);

                    channel.BasicQos(0, 10, false);
                    var subscription = new Subscription(channel, queueName, false);

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var deliveryArguments = subscription.Next();
                        var message = deliveryArguments.Body.DeSerializeText();

                        _log.LogDebug($"Message Received '{message}'");
                        subscription.Ack(deliveryArguments);
                    }
                }
            }

            _log.LogDebug($"AccountConsumerService background task is stopping.");

            return null;
        }
    }
}
