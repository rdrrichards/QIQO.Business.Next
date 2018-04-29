using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class OrderCompanyDeleteConsumerService : ConsumerServiceBase
    {
        public OrderCompanyDeleteConsumerService(ILogger<OrderCompanyDeleteConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Order, QueueConstants.Company, QueueConstants.Delete)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Delete}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Delete}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Company}{QueueConstants.Delete} Message Received '{message}'");
            });
        }
    }
}
