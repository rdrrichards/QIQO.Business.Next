namespace QIQO.Orders.Domain
{
    public enum QIQOOrderStatus
    {
        Scheduled = 1,
        Open = 2,
        InProcess = 3,
        Fulfilled = 4,
        PendingPayment = 5,
        Complete = 6,
        Canceled = 13
    }
}
