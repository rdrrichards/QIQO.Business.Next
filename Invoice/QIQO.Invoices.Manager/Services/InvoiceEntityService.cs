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
            OrderEntryDate = ent.OrderEntryDate,
            AccountKey = ent.AccountKey,
            AccountContactKey = ent.AccountContactKey,
            InvoiceNum = ent.InvoiceNumber,
            InvoiceCompleteDate = ent.InvoiceCompleteDate,
            InvoiceItemCount = ent.InvoiceItemCount,
            InvoiceValueSum = ent.InvoiceValueSum,
            InvoiceStatusDate = ent.InvoiceStatusDate,
            OrderShipDate = ent.OrderShipDate,
            AuditAddUserId = ent.AddedUserID,
            AuditAddDatetime = ent.AddedDateTime,
            AuditUpdateUserId = ent.UpdateUserID,
            AuditUpdateDatetime = ent.UpdateDateTime,
            InvoiceStatusKey = (int)ent.InvoiceStatus,
            AccountRepKey = ent.AccountRepKey,
            SalesRepKey = ent.SalesRepKey,
            FromEntityKey = ent.FromEntityKey,
            InvoiceEntryDate = ent.InvoiceEntryDate,
        };
    }
}
