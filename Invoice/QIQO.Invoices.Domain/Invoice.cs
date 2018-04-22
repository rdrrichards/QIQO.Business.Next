using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Invoices.Domain
{
    [DataContract]
    public class Invoice: IModel
    {
        public Invoice(InvoiceData invoiceData)
        {
            InvoiceKey = invoiceData.InvoiceKey;
            OrderEntryDate = invoiceData.OrderEntryDate;
            AccountKey = invoiceData.AccountKey;
            AccountContactKey = invoiceData.AccountContactKey;
            InvoiceNumber = invoiceData.InvoiceNum;
            InvoiceCompleteDate = invoiceData.InvoiceCompleteDate;
            InvoiceItemCount = invoiceData.InvoiceItemCount;
            InvoiceValueSum = invoiceData.InvoiceValueSum;
            InvoiceStatusDate = invoiceData.InvoiceStatusDate;
            OrderShipDate = invoiceData.OrderShipDate;
            AddedUserID = invoiceData.AuditAddUserId;
            AddedDateTime = invoiceData.AuditAddDatetime;
            UpdateUserID = invoiceData.AuditUpdateUserId;
            UpdateDateTime = invoiceData.AuditUpdateDatetime;
            InvoiceStatus = (QIQOInvoiceStatus)invoiceData.InvoiceStatusKey;
            AccountRepKey = invoiceData.AccountRepKey;
            SalesRepKey = invoiceData.SalesRepKey;
            FromEntityKey = invoiceData.FromEntityKey;
            InvoiceEntryDate = invoiceData.InvoiceEntryDate;
        }
        public Invoice(string invoiceNumber, DateTime invoiceEntryDate)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceEntryDate = invoiceEntryDate;
        }
        public int InvoiceKey { get; private set; }        
        public int FromEntityKey { get; private set; }        
        public int AccountKey { get; private set; }        
        public Account Account { get; private set; } //= new Account();        
        public int AccountContactKey { get; private set; }        
        public string InvoiceNumber { get; private set; }        
        public PersonBase InvoiceAccountContact { get; private set; } //= new PersonBase();        
        public int InvoiceItemCount { get; private set; }        
        public decimal InvoiceValueSum { get; private set; }        
        public DateTime OrderEntryDate { get; private set; }        
        public DateTime InvoiceEntryDate { get; private set; }        
        public DateTime InvoiceStatusDate { get; private set; }        
        public DateTime? OrderShipDate { get; private set; }        
        public DateTime? InvoiceCompleteDate { get; private set; }       
        public int SalesRepKey { get; private set; }        
        public Representative SalesRep { get; private set; } //= new Representative(QIQOPersonType.SalesRepresentative);        
        public int AccountRepKey { get; private set; }        
        public Representative AccountRep { get; private set; } //= new Representative(QIQOPersonType.AccountRepresentative);        
        public QIQOInvoiceStatus InvoiceStatus { get; private set; } = QIQOInvoiceStatus.New;        
        public InvoiceStatus InvoiceStatusData { get; private set; } //= new InvoiceStatus();        
        public List<InvoiceItem> InvoiceItems { get; private set; } = new List<InvoiceItem>();        
        public List<Comment> Comments { get; private set; } = new List<Comment>();        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
