namespace QIQO.Invoices.Domain
{
    public enum QIQOInvoiceStatus
    {
        New = 1,
        InProcess = 2,
        PendingPayment = 3,
        Complete = 4,
        Canceled = 5
    }
}
