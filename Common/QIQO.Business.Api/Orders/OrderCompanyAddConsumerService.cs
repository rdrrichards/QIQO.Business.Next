using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class OrderCompanyAddConsumerService : ConsumerServiceBase
    {
        public OrderCompanyAddConsumerService(ILogger<OrderCompanyAddConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Company, QueueConstants.Add)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Add}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Add}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Add} Message Received '{message}'");
            });
        }
    }
}
