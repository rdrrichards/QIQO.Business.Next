using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QIQO.MQ.Service.Consumers
{
    public interface IAccountConsumer : IConsumer { }
    public class AccountConsumer : Consumer, IAccountConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountConsumer> _log;

        public AccountConsumer(IConfiguration configuration, IServiceCollection services) : base(configuration)
        {
            _configuration = configuration;
            var svs = services.BuildServiceProvider();
            _log = svs.GetService<ILogger<AccountConsumer>>();

            StartAccountAddListener();
            StartAccountUpdateListener();
            StartAccountDeleteListener();
            StartAccountAuditListener();
        }
        private void StartAccountAddListener()
        {
            _log.LogDebug("StartAccountAddListener");
            var exchangeName = _configuration["QueueConfig:Account:Exchange"];
            var queueName = _configuration["QueueConfig:Account:RecieveAddQueueName"];
            var routingKey = _configuration["QueueConfig:Account:RecieveAddQueueName"];
            ReceiveMessages(exchangeName, queueName, routingKey);
        }
        private void StartAccountUpdateListener()
        {
            _log.LogDebug("StartAccountUpdateListener");
            var exchangeName = _configuration["QueueConfig:Account:Exchange"];
            var queueName = _configuration["QueueConfig:Account:RecieveUpdateQueueName"];
            var routingKey = _configuration["QueueConfig:Account:RecieveUpdateQueueName"];
            ReceiveMessages(exchangeName, queueName, routingKey);
        }
        private void StartAccountDeleteListener()
        {
            _log.LogDebug("StartAccountDeleteListener");
            var exchangeName = _configuration["QueueConfig:Account:Exchange"];
            var queueName = _configuration["QueueConfig:Account:RecieveDeleteQueueName"];
            var routingKey = _configuration["QueueConfig:Account:RecieveDeleteQueueName"];
            ReceiveMessages(exchangeName, queueName, routingKey);
        }
        private void StartAccountAuditListener()
        {
            _log.LogDebug("StartAccountAuditListener");
            var exchangeName = _configuration["QueueConfig:Account:Exchange"];
            var queueName = _configuration["QueueConfig:Account:RecieveAuditQueueName"];
            var routingKey = _configuration["QueueConfig:Account:RecieveAuditQueueName"];
            ReceiveMessages(exchangeName, queueName, routingKey);
        }
        ~AccountConsumer()
        {
            _log.LogDebug("AccountConsumer Stopping");
            StopRecieving();
        }
    }
}
