using QIQO.Accounts.Domain;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddViewModel
    {
        [Required]
        public int CompanyKey { get; set; }
        [Required]
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;
        [Required]
        public string AccountCode { get; set; } = string.Empty;
        [Required]
        public string AccountName { get; set; } = string.Empty;
        [Required]
        public string AccountDesc { get; set; } = string.Empty;
        public string AccountDba { get; set; } = string.Empty;
        [Required]
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressAddViewModel>? AccountAddresses { get; set; }
    }
}
