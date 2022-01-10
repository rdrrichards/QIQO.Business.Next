using System;
using System.Collections.Generic;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceUpdateViewModel
    {
        public int InvoiceKey { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
        public List<InvoiceItemAddViewModel> InvoiceItems { get; set; }
    }
}
