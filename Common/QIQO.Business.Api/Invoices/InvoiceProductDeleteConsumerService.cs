using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class InvoiceProductDeleteConsumerService : ConsumerServiceBase
    {
        public InvoiceProductDeleteConsumerService(ILogger<InvoiceProductDeleteConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Product, QueueConstants.Delete)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Product}{QueueConstants.Delete}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Product}{QueueConstants.Delete}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Product}{QueueConstants.Delete} Message Received '{message}'");
            });
        }
    }
}
