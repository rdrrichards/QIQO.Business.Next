using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Domain
{
    public class InvoiceStatus: IModel
    {        
        public int InvoiceStatusKey { get; set; }        
        public string InvoiceStatusCode { get; set; }        
        public string InvoiceStatusName { get; set; }        
        public string InvoiceStatusDesc { get; set; }        
        public string InvoiceStatusType { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
    }
}
