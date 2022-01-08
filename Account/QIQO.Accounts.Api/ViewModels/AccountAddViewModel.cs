using QIQO.Accounts.Domain;
using System;
using System.Collections.Generic;
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
        public string AccountCode { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        [Required]
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressAddViewModel> AccountAddresses { get; set; }
    }
}
