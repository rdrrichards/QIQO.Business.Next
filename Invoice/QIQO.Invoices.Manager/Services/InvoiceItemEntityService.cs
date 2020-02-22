using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
{
    public class InvoiceItemEntityService : IInvoiceItemEntityService
    {
        public InvoiceItem Map(InvoiceItemData ent) => new InvoiceItem(ent);

        public InvoiceItemData Map(InvoiceItem ent) => new InvoiceItemData
        {
            InvoiceItemKey = ent.InvoiceItemKey,
            InvoiceKey = ent.InvoiceKey,
            InvoiceItemSeq = ent.InvoiceItemSeq,
            ProductKey = ent.ProductKey,
            ProductName = ent.ProductName,
            ProductDesc = ent.ProductDesc,
            InvoiceItemQuantity = ent.InvoiceItemQuantity,
            // InvoiceItemEntryDate = ent.InvoiceItemShipDate,
            InvoiceItemCompleteDate = ent.InvoiceItemCompleteDate,
            InvoiceItemPricePer = ent.ItemPricePer,
            InvoiceItemLineSum = ent.InvoiceItemLineSum,
            AuditAddUserId = ent.AddedUserID,
            AuditAddDatetime = ent.AddedDateTime,
            AuditUpdateUserId = ent.UpdateUserID,
            AuditUpdateDatetime = ent.UpdateDateTime,
            InvoiceItemStatusKey = (int)ent.InvoiceItemStatus,
            BilltoAddrKey = 1,
            InvoiceItemAccountRepKey = 1,
            InvoiceItemSalesRepKey = 1,
            ShiptoAddrKey = 1
        };
    }
}
