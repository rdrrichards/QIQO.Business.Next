using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class Address : IModel
    {
        public int AddressKey { get; private set; }
        public QIQOAddressType AddressType { get; private set; } = QIQOAddressType.Billing;
        public int EntityKey { get; private set; }
        public QIQOEntityType EntityType { get; private set; } = QIQOEntityType.Account;
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
