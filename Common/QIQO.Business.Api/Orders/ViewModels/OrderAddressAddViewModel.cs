using QIQO.Orders.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Orders
{
    public class OrderAddressAddViewModel : OrderAddressBaseViewModel
    {
        [Required]
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
