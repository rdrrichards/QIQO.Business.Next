using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Invoices.Data
{
    public interface IInvoiceRepository : IRepository<InvoiceData>
    {
        // IEnumerable<InvoiceData> GetAll(int companyKey);
        IEnumerable<InvoiceData> GetAll(AccountData account);
        IEnumerable<InvoiceData> GetAllOpen(int companyKey);
        IEnumerable<InvoiceData> GetAllOpen(AccountData account);
        IEnumerable<InvoiceData> FindAll(int company_key, string pattern);
    }
}
