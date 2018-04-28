using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class InvoiceAccountDeleteConsumerService : ConsumerServiceBase
    {
        public InvoiceAccountDeleteConsumerService(ILogger<InvoiceAccountDeleteConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Account, QueueConstants.Delete)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Account}{QueueConstants.Delete}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Account}{QueueConstants.Delete}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Delete} Message Received '{message}'");
            });
        }
    }
}
