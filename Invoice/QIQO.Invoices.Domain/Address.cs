using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class Address : IModel
    {
        public Address(AddressData addressData)
        {
            AddressKey = addressData.AddressKey;
            AddressLine1 = addressData.AddressLine1;
            AddressLine2 = addressData.AddressLine2;
            AddressLine3 = addressData.AddressLine3;
            AddressLine4 = addressData.AddressLine4;
            AddressCity = addressData.AddressCity;
            AddressState = addressData.AddressStateProv;
            AddressPostalCode = addressData.AddressPostalCode;
            AddressActiveFlag = addressData.AddressActiveFlg == 1;
            AddressCounty = addressData.AddressCounty;
            AddressCountry = addressData.AddressCountry;
            AddressDefaultFlag = addressData.AddressDefaultFlg == 1;
            AddressNotes = addressData.AddressNotes;
            AddressType = (QIQOAddressType)addressData.AddressTypeKey;
            EntityKey = addressData.EntityKey;
            // EntityType = (QIQOEntityType)addressData.EntityTypeKey;
            AddedDateTime = addressData.AuditAddDatetime;
            AddedUserID = addressData.AuditAddUserId;
            UpdateDateTime = addressData.AuditUpdateDatetime;
            UpdateUserID = addressData.AuditUpdateUserId;
        }
        public int AddressKey { get; private set; }        
        public QIQOAddressType AddressType { get; private set; } = QIQOAddressType.Billing;        
        public AddressType AddressTypeData { get; private set; } //= new AddressType();        
        public int EntityKey { get; private set; }        
        // public QIQOEntityType EntityType { get; private set; } = QIQOEntityType.Account;        
        public string AddressLine1 { get; private set; }        
        public string AddressLine2 { get; private set; }        
        public string AddressLine3 { get; private set; }        
        public string AddressLine4 { get; private set; }        
        public string AddressCity { get; private set; }        
        public string AddressState { get; private set; }        
        public string AddressCounty { get; private set; }        
        public string AddressCountry { get; private set; }        
        public string AddressPostalCode { get; private set; }        
        public string AddressNotes { get; private set; }        
        public bool AddressDefaultFlag { get; private set; }        
        public bool AddressActiveFlag { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
