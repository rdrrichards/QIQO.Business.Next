using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddViewModel
    {
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderEntryDate { get; set; }
        public List<OrderItemAddViewModel>? OrderItems { get; set; }
    }
}
