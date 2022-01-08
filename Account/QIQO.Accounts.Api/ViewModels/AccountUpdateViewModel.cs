using QIQO.Accounts.Domain;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Api.Accounts
{
    public class AccountUpdateViewModel
    {
        public QIQOAccountType AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressUpdateViewModel> AccountAddresses { get; set; }
    }
}
