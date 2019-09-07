using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
{
    public class InvoiceItemEntityService : IInvoiceItemEntityService
    {
        public InvoiceItem Map(InvoiceItemData ent) => new InvoiceItem(ent);

        public InvoiceItemData Map(InvoiceItem ent) => new InvoiceItemData
        {
            InvoiceKey = ent.InvoiceKey,
        };
    }
}
