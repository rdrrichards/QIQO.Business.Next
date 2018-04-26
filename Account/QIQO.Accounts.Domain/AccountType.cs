using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class AccountType : IModel
    {
        public AccountType(AccountTypeData accountTypeData)
        {
            AccountTypeKey = accountTypeData.AccountTypeKey;
            AccountTypeCode = accountTypeData.AccountTypeCode;
            AccountTypeName = accountTypeData.AccountTypeName;
            AccountTypeDesc = accountTypeData.AccountTypeDesc;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            AddedUserID = accountTypeData.AuditAddUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
        }
        public AccountType(string accountTypeCode, string accountTypeName, string accountTypeDesc)
        {
            AccountTypeCode = accountTypeCode;
            AccountTypeName = accountTypeName;
            AccountTypeDesc = accountTypeDesc;
        }
        public int AccountTypeKey { get; private set; }
        public string AccountTypeCode { get; private set; }
        public string AccountTypeName { get; private set; }
        public string AccountTypeDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
