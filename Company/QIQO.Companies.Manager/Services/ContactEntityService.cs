using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Companies.Manager
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
