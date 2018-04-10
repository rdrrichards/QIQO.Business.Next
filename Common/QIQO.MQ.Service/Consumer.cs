using System;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace QIQO.MQ.Service
{
    public interface IConsumer
    {
        void ReceiveMessage(string exchgName, string qName, string rtKey);
    }
    public class Consumer : IConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly string hostName;
        private readonly string userName;
        private readonly string password;
        private string exchangeName = "Account";
        private string queueName = "account.add";
        private string routingKey = "account.*";
        private ConnectionFactory _factory;
        private IConnection _connection;


        public Consumer(IConfiguration configuration)
        {
            _configuration = configuration;
            hostName = _configuration["QueueConfig:Server"];
            userName = _configuration["QueueConfig:User"];
            password = _configuration["QueueConfig:Password"];
        }

        public void ReceiveMessage(string exchgName, string qName, string rtKey) {
            exchangeName = exchgName;
            queueName = qName;
            routingKey = rtKey;
            ProcessMessages();
        }

        private void ProcessMessages()
        {
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

                    while (true)
                    {
                        var deliveryArguments = subscription.Next();
                        // var message = deliveryArguments.Body.DeSerializeText();

                        // Console.WriteLine("Message Received '{0}'", message);
                        subscription.Ack(deliveryArguments);
                    }
                }
            }
        }
    }
}
