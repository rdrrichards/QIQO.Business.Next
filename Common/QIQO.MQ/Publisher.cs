using RabbitMQ.Client;

namespace QIQO.MQ
{
    public class Publisher
    {
        // private readonly ConsumerWorkService _something = new ConsumerWorkService();
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _model;

        private const string ExchangeName = "Topic_Exchange";
        private const string CardPaymentQueueName = "CardPaymentTopic_Queue";
        private const string PurchaseOrderQueueName = "PurchaseOrderTopic_Queue";
        private const string AllQueueName = "AllTopic_Queue";

        public void SendMessage(object thing, string routingKey)
        {
            Publish(thing.Serialize(), routingKey);
        }

        public void SendMessage(byte[] message, string routingKey)
        {
            Publish(message, routingKey);
        }
        private void Publish(byte[] message, string routingKey)
        {
            CreateConnection();
            _model.BasicPublish(ExchangeName, routingKey, null, message);
            Close();
        }

        private void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(ExchangeName, "topic");

            _model.QueueDeclare(CardPaymentQueueName, true, false, false, null);
            _model.QueueDeclare(PurchaseOrderQueueName, true, false, false, null);
            _model.QueueDeclare(AllQueueName, true, false, false, null);

            _model.QueueBind(CardPaymentQueueName, ExchangeName, "payment.card");
            _model.QueueBind(PurchaseOrderQueueName, ExchangeName, "payment.purchaseorder");
            _model.QueueBind(AllQueueName, ExchangeName, "payment.*");
        }
        private void Close()
        {
            _connection.Close();
        }
    }
}
