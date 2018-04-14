using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using QIQO.MQ;
using System;

namespace QIQO.Business.Api.Background
{
    public class ConsumerServiceBase : BackgroundServiceBase
    {
        private const string topic = "topic";
        private const string confBase = "QueueConfig";
        private readonly string _section;
        private readonly string _action;
        private ConnectionFactory _factory;
        private IConnection _connection;

        protected readonly ILogger<ConsumerServiceBase> _log;
        protected readonly string hostName;
        protected readonly string userName;
        protected readonly string password;
        protected readonly string exchangeName;
        protected readonly string queueName;
        protected readonly string routingKey;

        public ConsumerServiceBase(IConfiguration configuration, ILogger<ConsumerServiceBase> logger, string section, string action)
        {
            _log = logger;
            _section = section;
            _action = action;
            hostName = configuration[$"{confBase}:Server"];
            userName = configuration[$"{confBase}:User"];
            password = configuration[$"{confBase}:Password"];
            exchangeName = configuration[$"{confBase}:{_section}:Exchange"];
            queueName = configuration[$"{confBase}:{_section}:{_action}QueueName"];
            routingKey = configuration[$"{confBase}:{_section}:{_action}QueueName"];
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken) => null;

        protected Task Listen(CancellationToken stoppingToken, Action<object> listenAction)
        {
            return Task.Factory.StartNew(() =>
            {
                _log.LogDebug($"{_section}{_action}ConsumerService -> ExecuteAsync started");
                stoppingToken.Register(() => _log.LogDebug($"{_section}{_action}ConsumerService background task is stopping"));

                _factory = new ConnectionFactory { HostName = hostName, UserName = userName, Password = password };
                using (_connection = _factory.CreateConnection())
                {
                    using (var channel = _connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchangeName, topic);
                        channel.QueueDeclare(queueName, true, false, false, null);
                        channel.QueueBind(queueName, exchangeName, routingKey);

                        channel.BasicQos(0, 10, false);
                        var subscription = new Subscription(channel, queueName, false);

                        while (!stoppingToken.IsCancellationRequested)
                        {
                            var deliveryArguments = subscription.Next();
                            var message = deliveryArguments.Body.DeSerializeText();

                            listenAction.Invoke(message);
                            subscription.Ack(deliveryArguments);
                        }
                    }
                }
            });
        }
    }
}
