using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderUpdateViewModel
    {
        [Required]
        public int OrderKey { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public List<OrderItemUpdateViewModel>? OrderItems { get; set; }
    }
}
