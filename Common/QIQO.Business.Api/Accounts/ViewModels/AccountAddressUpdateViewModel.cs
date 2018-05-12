using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddressUpdateViewModel : AccountAddressBaseViewModel
    {
        [Required]
        public string UpdateUserID { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
