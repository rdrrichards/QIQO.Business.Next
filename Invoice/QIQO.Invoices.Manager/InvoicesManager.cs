using Dapr.Client;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Invoices.Manager
{
    public interface IInvoicesManager {
        Task SaveInvoiceAsync(Invoice invoice);
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceAsync(string invoiceCode);
        Task<List<Invoice>> FindInvoicesAsync(int companyKey, string term);
        Task DeleteInvoiceAsync(int invoiceKey);
        Task<List<Invoice>> GetOpenInvoicesAsync(int companyKey);
    }
    public class InvoicesManager : IInvoicesManager
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceEntityService _invoiceEntityService;
        private readonly ILogger<InvoicesManager> _log;
        private readonly DaprClient _daprClient;

        //private readonly IMQPublisher _mqPublisher;

        public InvoicesManager(ILogger<InvoicesManager> logger, DaprClient daprClient, //IMQPublisher mqPublisher,
            IInvoiceRepository invoiceRepository, IInvoiceEntityService invoiceEntityService)
        {
            _log = logger;
            _daprClient = daprClient;
            //_mqPublisher = mqPublisher;
            _invoiceRepository = invoiceRepository;
            _invoiceEntityService = invoiceEntityService;
        }
        public Task DeleteInvoiceAsync(int invoiceKey)
        {
            return Task.Run(() => _invoiceRepository.DeleteByID(invoiceKey));
        }

        public Task<Invoice> GetInvoiceAsync(string invoiceCode)
        {
            return Task.Run(() => {
                return new Invoice(_invoiceRepository.GetByCode(invoiceCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            return Task.Run(() => {
                return _invoiceEntityService.Map(_invoiceRepository.GetAll());
            });
        }

        public Task<List<Invoice>> FindInvoicesAsync(int companyKey, string term)
        {
            return Task.Run(() => {
                return _invoiceEntityService.Map(_invoiceRepository.FindAll(companyKey, term));
            });
        }

        public Task SaveInvoiceAsync(Invoice invoice)
        {
            return Task.Run(() => {
                _invoiceRepository.Save(_invoiceEntityService.Map(invoice));
                //_mqPublisher.Send(invoice, "invoice", "invoice.add", "invoice.add");
                _daprClient.PublishEventAsync("qiqo-pubsub", "qiqo-invoice-save", invoice);
            });
        }

        public Task<List<Invoice>> GetOpenInvoicesAsync(int companyKey)
        {
            return Task.Run(() => {
                return _invoiceEntityService.Map(_invoiceRepository.GetAllOpen(companyKey));
            });
        }
    }
}
