using QIQO.Orders.Domain;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddressUpdateViewModel : OrderAddressBaseViewModel
    {
        [Required]
        public string UpdateUserID { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
    }
    public class OrderAddressBaseViewModel
    {
        [Required]
        public int AddressKey { get; set; }
        [Required]
        public QIQOOrderAddressType AddressType { get; set; }
        [Required]
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressLine3 { get; set; } = string.Empty;
        public string AddressLine4 { get; set; } = string.Empty;
        [Required]
        public string AddressCity { get; set; } = string.Empty;
        [Required]
        public string AddressState { get; set; } = string.Empty;
        public string AddressCounty { get; set; } = string.Empty;
        public string AddressCountry { get; set; } = string.Empty;
        [Required]
        public string AddressPostalCode { get; set; } = string.Empty;
        public string AddressNotes { get; set; } = string.Empty;
        public bool AddressDefaultFlag { get; set; }
        public bool AddressActiveFlag { get; set; }
    }
}
