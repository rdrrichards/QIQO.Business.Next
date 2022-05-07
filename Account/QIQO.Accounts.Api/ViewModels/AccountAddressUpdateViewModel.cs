using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddressUpdateViewModel : AccountAddressBaseViewModel
    {
        [Required]
        public string UpdateUserID { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
    }
}
