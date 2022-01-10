using System;
using System.Collections.Generic;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddViewModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
        public List<InvoiceItemAddViewModel> InvoiceItems { get; set; }
    }
}
