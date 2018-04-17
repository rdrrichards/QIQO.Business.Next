using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class InvoiceData : CommonData, IEntity
    { 
        public int InvoiceKey { get; set; }
        public int FromEntityKey { get; set; }
        public int AccountKey { get; set; }
        public int AccountContactKey { get; set; }
        public string InvoiceNum { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public int InvoiceStatusKey { get; set; }
        public DateTime InvoiceStatusDate { get; set; }
        public DateTime? OrderShipDate { get; set; }
        public int AccountRepKey { get; set; }
        public int SalesRepKey { get; set; }
        public DateTime? InvoiceCompleteDate { get; set; }
        public decimal InvoiceValueSum { get; set; }
        public int InvoiceItemCount { get; set; }
    }
}