using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class InvoiceItem: IModel
    {
        public InvoiceItem(InvoiceItemData invoiceItemData)
        {
            InvoiceKey = invoiceItemData.InvoiceKey;
            InvoiceItemSeq = invoiceItemData.InvoiceItemSeq;
            InvoiceItemKey = invoiceItemData.InvoiceItemKey;
            ProductKey = invoiceItemData.ProductKey;
            ProductName = invoiceItemData.ProductName;
            ProductDesc = invoiceItemData.ProductDesc;
            InvoiceItemQuantity = invoiceItemData.InvoiceItemQuantity;
            OrderItemShipDate = invoiceItemData.OrderItemShipDate;
            InvoiceItemCompleteDate = invoiceItemData.InvoiceItemCompleteDate;
            ItemPricePer = invoiceItemData.InvoiceItemPricePer;
            InvoiceItemLineSum = invoiceItemData.InvoiceItemLineSum;
            AddedUserID = invoiceItemData.AuditAddUserId;
            AddedDateTime = invoiceItemData.AuditAddDatetime;
            UpdateUserID = invoiceItemData.AuditUpdateUserId;
            UpdateDateTime = invoiceItemData.AuditUpdateDatetime;
            InvoiceItemStatus = (QIQOInvoiceItemStatus)invoiceItemData.InvoiceItemStatusKey;
            FromEntityKey = invoiceItemData.OrderItemKey;
        }
        public int InvoiceItemKey { get; private set; }        
        public int FromEntityKey { get; private set; }        
        public int InvoiceKey { get; private set; }        
        public int InvoiceItemSeq { get; private set; }        
        public int ProductKey { get; private set; }        
        public string ProductName { get; private set; }        
        public string ProductDesc { get; private set; }        
        public int InvoiceItemQuantity { get; private set; }        
        public Address OrderItemShipToAddress { get; private set; } //= new Address();        
        public Address OrderItemBillToAddress { get; private set; } //= new Address();
        //public DateTime InvoiceEntry        
        public DateTime? OrderItemShipDate { get; private set; }        
        public DateTime? InvoiceItemCompleteDate { get; private set; }        
        public decimal ItemPricePer { get; private set; }        
        public decimal InvoiceItemLineSum { get; private set; }        
        public Representative SalesRep { get; private set; } //= new Representative(QIQOPersonType.SalesRepresentative);        
        public Representative AccountRep { get; private set; } //= new Representative(QIQOPersonType.AccountRepresentative);        
        public QIQOInvoiceItemStatus InvoiceItemStatus { get; private set; } = QIQOInvoiceItemStatus.New;        
        // public InvoiceItemStatus InvoiceItemStatusData { get; private set; } = new InvoiceItemStatus();        
        public Product InvoiceItemProduct { get; private set; } //= new Product();        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
