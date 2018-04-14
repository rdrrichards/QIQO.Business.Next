using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class AccountAuditConsumerService : ConsumerServiceBase
    {
        public AccountAuditConsumerService(ILogger<AccountAuditConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Account, QueueConstants.Audit)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Audit}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Account}{QueueConstants.Audit}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Audit} Message Received '{message}'");
            });
        }
    }
}
