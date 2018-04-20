using QIQO.Accounts.Domain;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddViewModel
    {
        public int CompanyKey { get; set; }
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
    }
    public class AccountUpdateViewModel
    {
        public int CompanyKey { get; set; }
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
    }
}
