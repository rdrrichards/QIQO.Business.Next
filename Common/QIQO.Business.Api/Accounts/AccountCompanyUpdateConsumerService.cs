using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class AccountCompanyUpdateConsumerService : ConsumerServiceBase
    {
        public AccountCompanyUpdateConsumerService(ILogger<AccountCompanyUpdateConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Company, QueueConstants.Update)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Company}{QueueConstants.Update}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Company}{QueueConstants.Update}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Company}{QueueConstants.Update} Message Received '{message}'");
            });
        }
    }
}
