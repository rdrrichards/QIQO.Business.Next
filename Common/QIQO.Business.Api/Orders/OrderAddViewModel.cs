using System;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddViewModel
    {
        public string OrderNumber { get; set; }
        public DateTime OrderEntryDate { get; set; }
    }
    public class OrderUpdateViewModel
    {
        public string OrderNumber { get; set; }
        public DateTime OrderEntryDate { get; set; }
    }
}
