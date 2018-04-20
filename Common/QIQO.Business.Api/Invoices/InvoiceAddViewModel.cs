using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
