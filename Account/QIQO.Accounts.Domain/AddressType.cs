using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class AddressType : IModel
    {
        public AddressType(AddressTypeData accountTypeData)
        {
            AddressTypeKey = accountTypeData.AddressTypeKey;
            AddressTypeCode = accountTypeData.AddressTypeCode;
            AddressTypeName = accountTypeData.AddressTypeName;
            AddressTypeDesc = accountTypeData.AddressTypeDesc;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            AddedUserID = accountTypeData.AuditAddUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
        }
        public AddressType(string accountTypeCode, string accountTypeName, string accountTypeDesc)
        {
            AddressTypeCode = accountTypeCode;
            AddressTypeName = accountTypeName;
            AddressTypeDesc = accountTypeDesc;
        }
        public int AddressTypeKey { get; private set; }
        public string AddressTypeCode { get; private set; }
        public string AddressTypeName { get; private set; }
        public string AddressTypeDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
