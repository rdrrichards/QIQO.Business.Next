using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Api.Background;
using System.Threading;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class InvoiceAccountAddConsumerService : ConsumerServiceBase
    {
        public InvoiceAccountAddConsumerService(ILogger<InvoiceAccountAddConsumerService> logger, IConfiguration configuration) 
            : base(configuration, logger, QueueConstants.Account, QueueConstants.Add)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Account}{QueueConstants.Add}ConsumerService initiated");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Account}{QueueConstants.Add}ConsumerService ExecuteAsync Called");
            await Listen(stoppingToken, (message) =>
            {
                _log.LogDebug($"{QueueConstants.Invoice}{QueueConstants.Add} Message Received '{message}'");
            });
        }
    }
}
