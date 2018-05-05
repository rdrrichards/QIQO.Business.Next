using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddViewModel
    {
        [Required]
        public string OrderNumber { get; set; }
        public DateTime OrderEntryDate { get; set; }
    }
    public class OrderUpdateViewModel
    {
        public DateTime OrderEntryDate { get; set; }
    }
}
