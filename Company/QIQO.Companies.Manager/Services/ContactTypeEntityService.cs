using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Accounts.Manager
{
    public class ContactTypeEntityService : IContactTypeEntityService
    {
        public ContactType Map(ContactTypeData commentData) => new ContactType(commentData);
        public ContactTypeData Map(ContactType comment) => new ContactTypeData()
        {
            ContactTypeKey = comment.ContactTypeKey,
            ContactTypeCode = comment.ContactTypeCode,
            ContactTypeName = comment.ContactTypeName,
            ContactTypeDesc = comment.ContactTypeDesc
        };
    }
}
