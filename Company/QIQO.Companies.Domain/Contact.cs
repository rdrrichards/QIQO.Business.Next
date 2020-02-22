using QIQO.Business.Core.Contracts;
using QIQO.Companies.Data;
using System;

namespace QIQO.Companies.Domain
{
    public class Contact : IModel
    {
        public Contact(ContactData contactData)
        {
            ContactKey = contactData.ContactKey;
            ContactTypeKey = contactData.ContactTypeKey;
            ContactType = (QIQOCompanyContactType)contactData.ContactTypeKey;
            ContactActiveFlg = contactData.ContactActiveFlg;
            ContactDefaultFlg = contactData.ContactDefaultFlg;
            ContactValue = contactData.ContactValue;
            EntityKey = contactData.EntityKey;
            EntityTypeKey = contactData.EntityTypeKey;
            AddedUserID = contactData.AuditAddUserId;
            AddedDateTime = contactData.AuditAddDatetime;
            UpdateUserID = contactData.AuditUpdateUserId;
            UpdateDateTime = contactData.AuditUpdateDatetime;
        }
        public int ContactKey { get; private set; }
        public int EntityKey { get; private set; }
        public int EntityTypeKey { get; private set; }
        public int ContactTypeKey { get; private set; }
        public QIQOCompanyContactType ContactType { get; private set; } = QIQOCompanyContactType.CellPhone;
        public string ContactValue { get; private set; }
        public int ContactDefaultFlg { get; private set; }
        public int ContactActiveFlg { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

    }
}
