using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Accounts.Domain
{
    public class Account : IModel
    {
        // public Account() { }
        public Account(int companyKey, QIQOAccountType accountType, string accountCode, string accountName,
            string accountDesc, string accountDba, DateTime startDate, DateTime? endDate)
        {
            CompanyKey = companyKey;
            AccountType = accountType;
            AccountCode = accountCode;
            AccountName = accountName;
            AccountDesc = accountDesc;
            AccountDba = accountDba;
            AccountStartDate = startDate;
            AccountEndDate = endDate ?? DateTime.Now.AddYears(99);
        }
        public Account(AccountData accountData)
        {
            CompanyKey = accountData.CompanyKey;
            AccountType = (QIQOAccountType)accountData.AccountTypeKey;
            AccountCode = accountData.AccountCode;
            AccountName = accountData.AccountName;
            AccountDesc = accountData.AccountDesc;
            AccountDba = accountData.AccountDba;
            AccountStartDate = accountData.AccountStartDate;
            AccountEndDate = accountData.AccountEndDate;
        }

        public int AccountKey { get; private set; }
        public int CompanyKey { get; private set; }
        public QIQOAccountType AccountType { get; private set; } = QIQOAccountType.Business;
        public string AccountCode { get; private set; }
        public string AccountName { get; private set; }
        public string AccountDesc { get; private set; }
        public string AccountDba { get; private set; }
        public DateTime AccountStartDate { get; private set; }
        public DateTime AccountEndDate { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
        //public List<Address> Addresses { get; private set; } = new List<Address>();
        //public List<EntityAttribute> AccountAttributes { get; private set; } = new List<EntityAttribute>();
        //public List<FeeSchedule> FeeSchedules { get; private set; } = new List<FeeSchedule>();
        //public List<AccountPerson> Employees { get; private set; } = new List<AccountPerson>();
        //public List<Contact> Contacts { get; private set; } = new List<Contact>();
        //public List<Comment> Comments { get; private set; } = new List<Comment>();
    }

    public enum QIQOAccountType
    {
        TestAccount = 1,
        Business = 2
    }
}
