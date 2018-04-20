using QIQO.Invoices.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Invoices.Manager
{
    public interface IInvoicesManager {
        Task SaveInvoiceAsync(Invoice company);
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceAsync(string companyCode);
        Task DeleteInvoiceAsync(int companyKey);
        Task UpdateInvoiceAsync(Invoice company);
    }
    public class InvoicesManager : IInvoicesManager
    {
        public Task DeleteInvoiceAsync(int companyKey)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetInvoiceAsync(string companyCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveInvoiceAsync(Invoice company)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInvoiceAsync(Invoice company)
        {
            throw new NotImplementedException();
        }
    }
}
