namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddViewModel
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceEntryDate { get; set; }
        public List<InvoiceItemAddViewModel>? InvoiceItems { get; set; }
    }
}
