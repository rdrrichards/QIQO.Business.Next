using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Domain
{
    public class InvoiceItemStatus: IModel
    {       
        public int InvoiceItemStatusKey { get; set; }        
        public string InvoiceItemStatusType { get; set; }        
        public string InvoiceItemStatusCode { get; set; }        
        public string InvoiceItemStatusName { get; set; }        
        public string InvoiceItemStatusDesc { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
    }
}
