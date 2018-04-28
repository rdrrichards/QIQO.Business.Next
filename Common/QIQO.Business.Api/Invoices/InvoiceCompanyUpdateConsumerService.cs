using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class InvoiceCompanyUpdateConsumerService : ConsumerServiceBase
    {
        public InvoiceCompanyUpdateConsumerService(ILogger<InvoiceCompanyUpdateConsumerService> logger, IConfiguration configuration)
            : base(configuration, logger, QueueConstants.Company, QueueConstants.Update)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Company}{QueueConstants.Update}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Company}{QueueConstants.Update}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Company}{QueueConstants.Update} Message Received '{message}'");
            });
        }
    }
}
