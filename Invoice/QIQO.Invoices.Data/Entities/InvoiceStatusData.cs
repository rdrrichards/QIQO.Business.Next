namespace QIQO.Invoices.Data
{
    public class InvoiceStatusData : CommonData
    {
        public int InvoiceStatusKey { get; set; }
        public string InvoiceStatusCode { get; set; }
        public string InvoiceStatusName { get; set; }
        public string InvoiceStatusType { get; set; }
        public string InvoiceStatusDesc { get; set; }
    }
}