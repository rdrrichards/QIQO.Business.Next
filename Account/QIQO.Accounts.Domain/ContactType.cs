using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class ContactType : IModel
    {
        public ContactType(ContactTypeData accountTypeData)
        {
            ContactTypeKey = accountTypeData.ContactTypeKey;
            ContactTypeCode = accountTypeData.ContactTypeCode;
            ContactTypeName = accountTypeData.ContactTypeName;
            ContactTypeDesc = accountTypeData.ContactTypeDesc;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            AddedUserID = accountTypeData.AuditAddUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
        }
        public ContactType(string accountTypeCode, string accountTypeName, string accountTypeDesc)
        {
            ContactTypeCode = accountTypeCode;
            ContactTypeName = accountTypeName;
            ContactTypeDesc = accountTypeDesc;
        }
        public int ContactTypeKey { get; private set; }
        public string ContactTypeCode { get; private set; }
        public string ContactTypeName { get; private set; }
        public string ContactTypeDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
