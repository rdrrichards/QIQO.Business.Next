using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
// using RabbitMQ.Client.MessagePatterns;
using System;
using RabbitMQ.Client.Events;
using System.Text;

namespace QIQO.Business.Api.Background
{
    public class ConsumerServiceBase : BackgroundServiceBase
    {
        private const string _topic = "topic";
        private const string _confBase = "QueueConfig";
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

        public ConsumerServiceBase(IConfiguration configuration, ILogger<ConsumerServiceBase> logger, string exchange, string section, string action)
        {
            _log = logger;
            _section = section;
            _action = action;
            hostName = configuration[$"{_confBase}:Server"];
            userName = configuration[$"{_confBase}:User"];
            password = configuration[$"{_confBase}:Password"];
            exchangeName = exchange; // configuration[$"{confBase}:{_section}:Exchange"];
            queueName = configuration[$"{_confBase}:{_section}:{_action}QueueName"];
            routingKey = configuration[$"{_confBase}:{_section}:{_action}QueueName"];
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken) => null;

        protected Task Listen(CancellationToken stoppingToken, Action<object> listenAction)
        {

            return Task.Factory.StartNew(() =>
            {
                _log.LogDebug($"{_section}{_action}ConsumerService -> ExecuteAsync started");
                stoppingToken.Register(() => _log.LogDebug($"{_section}{_action}ConsumerService background task is stopping"));

                _factory = new ConnectionFactory { HostName = hostName, UserName = userName, Password = password };

                try
                {
                    using (_connection = _factory.CreateConnection())
                    {
                        using var channel = _connection.CreateModel();
                        channel.ExchangeDeclare(exchangeName, _topic);
                        channel.QueueDeclare(queueName, true, false, false, null);
                        channel.QueueBind(queueName, exchangeName, routingKey);

                        channel.BasicQos(0, 10, false);
                        // var subscription = new Subscription(channel, queueName, false);
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.Span;
                            var message = Encoding.UTF8.GetString(body);
                            listenAction.Invoke(message);
                                // subscription.Ack(ea);
                            };
                        channel.BasicConsume(queue: queueName,
                                             autoAck: true,
                                             consumer: consumer);

                        //while (!stoppingToken.IsCancellationRequested)
                        //{
                        //    var deliveryArguments = subscription.Next();
                        //    var message = deliveryArguments.Body.DeSerializeText();

                        //    listenAction.Invoke(message);
                        //    subscription.Ack(deliveryArguments);
                        //}
                    }
                }
                catch (Exception e)
                {
                    _log.LogError("Error while attempting to connect to the queue service; see below. Ensure that the service is running.");
                    _log.LogError(e.ToString());
                    //return Task.FromException(e);
                }

            });

        }
    }
}
