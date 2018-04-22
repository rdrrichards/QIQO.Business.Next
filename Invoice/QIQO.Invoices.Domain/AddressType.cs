using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class AddressType : IModel
    {
        public AddressType(AddressTypeData addressTypeData)
        {
            AddressTypeKey = addressTypeData.AddressTypeKey;
            AddressTypeCode = addressTypeData.AddressTypeCode;
            AddressTypeName = addressTypeData.AddressTypeName;
            AddressTypeDesc = addressTypeData.AddressTypeDesc;
            AddedUserID = addressTypeData.AuditAddUserId;
            AddedDateTime = addressTypeData.AuditAddDatetime;
            UpdateUserID = addressTypeData.AuditUpdateUserId;
            UpdateDateTime = addressTypeData.AuditUpdateDatetime;
        }
        public int AddressTypeKey { get; private set; }
        //public string AddressCategory { get; private set; }        
        public string AddressTypeCode { get; private set; }        
        public string AddressTypeName { get; private set; }        
        public string AddressTypeDesc { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
