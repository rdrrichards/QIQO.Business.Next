using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class AccountProductUpdateConsumerService : ConsumerServiceBase
    {
        public AccountProductUpdateConsumerService(ILogger<AccountProductUpdateConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Product, QueueConstants.Update)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Product}{QueueConstants.Update}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Product}{QueueConstants.Update}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Product}{QueueConstants.Update} Message Received '{message}'");
            });
        }
    }
}
