using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class AccountType : IModel
    {
        public AccountType(AccountTypeData accountTypeData)
        {
            AccountTypeKey = accountTypeData.AccountTypeKey;
            AccountTypeCode = accountTypeData.AccountTypeCode;
            AccountTypeName = accountTypeData.AccountTypeName;
            AccountTypeDesc = accountTypeData.AccountTypeDesc;
            AddedUserID = accountTypeData.AuditAddUserId;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
        }
        public int AccountTypeKey { get; private set; }
        //public string AccountTypeCategory { get; private set; }        
        public string AccountTypeCode { get; private set; }        
        public string AccountTypeName { get; private set; }        
        public string AccountTypeDesc { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
