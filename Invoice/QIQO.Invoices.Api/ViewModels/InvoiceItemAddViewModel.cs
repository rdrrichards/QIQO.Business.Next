using QIQO.Invoices.Domain;
using System;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceItemAddViewModel
    {
        public int InvoiceItemKey { get; set; }
        public int InvoiceKey { get; set; }
        public int InvoiceItemSeq { get; set; }
        public int ProductKey { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int InvoiceItemQuantity { get; set; }
        public InvoiceAddressAddViewModel InvoiceItemShipToAddress { get; set; }
        public InvoiceAddressAddViewModel InvoiceItemBillToAddress { get; set; }
        public DateTime? InvoiceItemShipDate { get; set; }
        public DateTime? InvoiceItemCompleteDate { get; set; }
        public decimal ItemPricePer { get; set; }
        public decimal InvoiceItemLineSum { get; set; }
        public int SalesRepKey { get; set; }
        public int AccountRepKey { get; set; }
        public QIQOInvoiceItemStatus InvoiceItemStatus { get; set; } = QIQOInvoiceItemStatus.New;
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
