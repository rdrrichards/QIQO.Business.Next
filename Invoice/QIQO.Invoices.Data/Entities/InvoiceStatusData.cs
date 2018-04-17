using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class InvoiceStatusData : CommonData, IEntity
    {
        public int InvoiceStatusKey { get; set; }
        public string InvoiceStatusCode { get; set; }
        public string InvoiceStatusName { get; set; }
        public string InvoiceStatusType { get; set; }
        public string InvoiceStatusDesc { get; set; }
    }
}