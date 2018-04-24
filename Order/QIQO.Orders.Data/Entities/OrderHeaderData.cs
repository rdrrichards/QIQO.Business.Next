using System;

namespace QIQO.Orders.Data
{
    public class OrderHeaderData : CommonData
    {
        public int OrderKey { get; set; }
        public int AccountKey { get; set; }
        public int AccountContactKey { get; set; }
        public string OrderNum { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public int OrderStatusKey { get; set; }
        public DateTime OrderStatusDate { get; set; }
        public DateTime? OrderShipDate { get; set; }
        public int AccountRepKey { get; set; }
        public DateTime? OrderCompleteDate { get; set; }
        public decimal OrderValueSum { get; set; }
        public int OrderItemCount { get; set; }
        public DateTime? DeliverByDate { get; set; }
        public int SalesRepKey { get; set; }
    } 
}