namespace QIQO.Orders.Data
{
    public class OrderStatusData : CommonData
    {
        public int OrderStatusKey { get; set; }
        public string OrderStatusCode { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusType { get; set; }
        public string OrderStatusDesc { get; set; }
    }
}