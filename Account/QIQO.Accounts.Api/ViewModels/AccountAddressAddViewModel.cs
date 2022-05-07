using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddressAddViewModel : AccountAddressBaseViewModel
    {
        [Required]
        public string? AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
