using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class InvoiceStatus: IModel
    {
        public InvoiceStatus(InvoiceStatusData invoiceStatusData)
        {
            InvoiceStatusKey = invoiceStatusData.InvoiceStatusKey;
            InvoiceStatusCode = invoiceStatusData.InvoiceStatusCode;
            InvoiceStatusName = invoiceStatusData.InvoiceStatusName;
            InvoiceStatusType = invoiceStatusData.InvoiceStatusType;
            InvoiceStatusDesc = invoiceStatusData.InvoiceStatusDesc;
            AddedUserID = invoiceStatusData.AuditAddUserId;
            AddedDateTime = invoiceStatusData.AuditAddDatetime;
            UpdateUserID = invoiceStatusData.AuditUpdateUserId;
            UpdateDateTime = invoiceStatusData.AuditUpdateDatetime;
        }
        public int InvoiceStatusKey { get; private set; }        
        public string InvoiceStatusCode { get; private set; }        
        public string InvoiceStatusName { get; private set; }        
        public string InvoiceStatusDesc { get; private set; }        
        public string InvoiceStatusType { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
