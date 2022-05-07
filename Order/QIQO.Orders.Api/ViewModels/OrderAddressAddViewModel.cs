using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddressAddViewModel : OrderAddressBaseViewModel
    {
        [Required]
        public string AddedUserID { get; set; } = string.Empty;
        public DateTime AddedDateTime { get; set; }
    }
}
