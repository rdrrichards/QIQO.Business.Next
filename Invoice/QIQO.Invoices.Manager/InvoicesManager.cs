﻿using Microsoft.Extensions.Logging;
using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;
using QIQO.MQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;

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
            return Task.Factory.StartNew(() => _invoiceRepository.DeleteByID(invoiceKey));
        }

        public Task<Invoice> GetInvoiceAsync(string invoiceCode)
        {
            return Task.Factory.StartNew(() => {
                return new Invoice(_invoiceRepository.GetByCode(invoiceCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            return Task.Factory.StartNew(() => {
                return _invoiceEntityService.Map(_invoiceRepository.GetAll());
            });
        }

        public Task<List<Invoice>> FindInvoicesAsync(int companyKey, string term)
        {
            return Task.Factory.StartNew(() => {
                return _invoiceEntityService.Map(_invoiceRepository.FindAll(companyKey, term));
            });
        }

        public Task SaveInvoiceAsync(Invoice invoice)
        {
            return Task.Factory.StartNew(() => {
                _invoiceRepository.Save(_invoiceEntityService.Map(invoice));
                _mqPublisher.Send(invoice, "invoice", "invoice.add", "invoice.add");
            });
        }

        public Task<List<Invoice>> GetOpenInvoicesAsync(int companyKey)
        {
            return Task.Factory.StartNew(() => {
                return _invoiceEntityService.Map(_invoiceRepository.GetAllOpen(companyKey));
            });
        }
    }
}
