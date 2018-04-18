using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Invoices.Data
{
    public interface IInvoiceItemRepository : IRepository<InvoiceItemData>
    {
        IEnumerable<InvoiceItemData> GetAll(InvoiceData invoice);
        InvoiceItemData GetByOrderItemID(int order_item_key);
    }
}
