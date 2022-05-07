using QIQO.Accounts.Domain;

namespace QIQO.Business.Api.Accounts
{
    public class AccountUpdateViewModel
    {
        public QIQOAccountType AccountType { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string AccountDesc { get; set; } = string.Empty;
        public string AccountDba { get; set; } = string.Empty;
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressUpdateViewModel>? AccountAddresses { get; set; }
    }
}
