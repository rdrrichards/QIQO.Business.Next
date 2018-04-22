using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class InvoiceItemStatus: IModel
    {
        public InvoiceItemStatus(InvoiceStatusData invoiceStatusData)
        {
            InvoiceItemStatusKey = invoiceStatusData.InvoiceStatusKey;
            InvoiceItemStatusCode = invoiceStatusData.InvoiceStatusCode;
            InvoiceItemStatusName = invoiceStatusData.InvoiceStatusName;
            InvoiceItemStatusType = invoiceStatusData.InvoiceStatusType;
            InvoiceItemStatusDesc = invoiceStatusData.InvoiceStatusDesc;
            AddedUserID = invoiceStatusData.AuditAddUserId;
            AddedDateTime = invoiceStatusData.AuditAddDatetime;
            UpdateUserID = invoiceStatusData.AuditUpdateUserId;
            UpdateDateTime = invoiceStatusData.AuditUpdateDatetime;
        }
        public int InvoiceItemStatusKey { get; private set; }        
        public string InvoiceItemStatusType { get; private set; }        
        public string InvoiceItemStatusCode { get; private set; }        
        public string InvoiceItemStatusName { get; private set; }        
        public string InvoiceItemStatusDesc { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
