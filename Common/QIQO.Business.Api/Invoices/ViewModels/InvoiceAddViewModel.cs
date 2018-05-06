using System;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddViewModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
    }
    public class InvoiceUpdateViewModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
    }
}
