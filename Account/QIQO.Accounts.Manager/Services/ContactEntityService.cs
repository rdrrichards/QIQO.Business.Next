using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class ContactEntityService : IContactEntityService
    {
        public Contact Map(ContactData contactData) => new Contact(contactData);
        public ContactData Map(Contact contact) => new ContactData()
        {
            ContactKey = contact.ContactKey,
            ContactTypeKey = (int)contact.ContactType,
            ContactActiveFlg = contact.ContactActiveFlg,
            ContactDefaultFlg = contact.ContactDefaultFlg,
            ContactValue = contact.ContactValue,
            EntityKey = contact.EntityKey,
            EntityTypeKey = contact.EntityTypeKey
        };
    }
}
