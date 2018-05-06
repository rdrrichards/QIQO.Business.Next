using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class OrderAccountDeleteConsumerService : ConsumerServiceBase
    {
        public OrderAccountDeleteConsumerService(ILogger<OrderAccountDeleteConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Order, QueueConstants.Account, QueueConstants.Delete)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Account}{QueueConstants.Delete}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Account}{QueueConstants.Delete}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Order}{QueueConstants.Account}{QueueConstants.Delete} Message Received '{message}'");
            });
        }
    }
}
