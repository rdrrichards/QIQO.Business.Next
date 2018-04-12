using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;

namespace QIQO.Business.Api.Background
{
    // This will not really work in tit's current form
    public class ConsumerServiceBase : BackgroundServiceBase
    {
        private readonly ILogger<ConsumerServiceBase> _log;
        private readonly string _section;
        private readonly IConfiguration _configuration;
        private ConnectionFactory _factory;
        private IConnection _connection;

        private const string confBase = "QueueConfig";
        protected readonly string HostName;
        protected readonly string UserName;
        protected readonly string Password;
        protected readonly string ExchangeName;
        protected readonly string QueueName;
        protected readonly string RoutingKey;

        public ConsumerServiceBase(IConfiguration configuration, ILogger<ConsumerServiceBase> logger, string section)
        {
            _log = logger;
            _section = section;
            HostName = configuration[$"{confBase}:Server"];
            UserName = configuration[$"{confBase}:User"];
            Password = configuration[$"{confBase}:Password"];
            ExchangeName = configuration[$"{confBase}:{_section}:Exchange"];
            QueueName = configuration[$"{confBase}:{_section}:RecieveAddQueueName"];
            RoutingKey = configuration[$"{confBase}:{_section}:RecieveAddQueueName"];
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{_section}ConsumerService -> ExecuteAsync started");
            stoppingToken.Register(() => _log.LogDebug($"{_section}ConsumerService background task is stopping."));

            _factory = new ConnectionFactory { HostName = HostName, UserName = UserName, Password = Password };
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "topic");
                    channel.QueueDeclare(QueueName, true, false, false, null);
                    channel.QueueBind(QueueName, ExchangeName, RoutingKey);

                    channel.BasicQos(0, 10, false);
                    var subscription = new Subscription(channel, QueueName, false);

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var deliveryArguments = subscription.Next();
                        // var message = deliveryArguments.Body.DeSerializeText();

                        // Console.WriteLine("Message Received '{0}'", message);
                        subscription.Ack(deliveryArguments);
                    }
                }
            }
            _log.LogDebug($"{_section}ConsumerService background task is stopping.");
            return null;
        }
    }
}
