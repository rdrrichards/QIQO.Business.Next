namespace QIQO.Orders.Domain
{
    public enum QIQOOrderItemStatus
    {
        Scheduled = 7,
        Open = 8,
        InProcess = 9,
        Fulfilled = 10,
        PendingPayment = 11,
        Complete = 12,
        Canceled = 14
    }
}
