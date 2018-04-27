using Microsoft.Extensions.Logging;
using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;
using QIQO.MQ;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Invoices.Manager
{
    public interface IInvoicesManager {
        Task SaveInvoiceAsync(Invoice invoice);
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceAsync(string invoiceCode);
        Task DeleteInvoiceAsync(int invoiceKey);
        Task UpdateInvoiceAsync(Invoice invoice);
    }
    public class InvoicesManager : IInvoicesManager
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceEntityService _invoiceEntityService;
        private readonly ILogger<InvoicesManager> _log;
        private readonly IMQPublisher _mqPublisher;

        public InvoicesManager(ILogger<InvoicesManager> logger, IMQPublisher mqPublisher,
            IInvoiceRepository invoiceRepository, IInvoiceEntityService invoiceEntityService)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _invoiceRepository = invoiceRepository;
            _invoiceEntityService = invoiceEntityService;
        }
        public Task DeleteInvoiceAsync(int invoiceKey)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetInvoiceAsync(string invoiceCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
