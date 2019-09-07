using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
{
    public class InvoiceEntityService : IInvoiceEntityService
    {
        public Invoice Map(InvoiceData ent) => new Invoice(ent);

        public InvoiceData Map(Invoice ent) => new InvoiceData
        {
            InvoiceKey = ent.InvoiceKey,
        };
    }
}
