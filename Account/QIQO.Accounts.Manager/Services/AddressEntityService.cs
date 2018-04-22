using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class AddressEntityService : IAddressEntityService
    {
        public Address Map(AddressData ent)
        {
            return new Address
            {
                //AddressKey = ent.AddressKey,
                //AddressLine1 = ent.AddressLine1,
                //AddressLine2 = ent.AddressLine2,
                //AddressLine3 = ent.AddressLine3,
                //AddressLine4 = ent.AddressLine4,
                //AddressCity = ent.AddressCity,
                //AddressState = ent.AddressStateProv,
                //AddressPostalCode = ent.AddressPostalCode,
                //AddressActiveFlag = ent.AddressActiveFlg == 1,
                //AddressCounty = ent.AddressCounty,
                //AddressCountry = ent.AddressCountry,
                //AddressDefaultFlag = ent.AddressDefaultFlg == 1,
                //AddressNotes = ent.AddressNotes,
                //AddressType = (QIQOAddressType)ent.AddressTypeKey,
                //EntityKey = ent.EntityKey,
                //EntityType = (QIQOEntityType)ent.EntityTypeKey,
                //AddedDateTime = ent.AuditAddDatetime,
                //AddedUserID = ent.AuditAddUserId,
                //UpdateDateTime = ent.AuditUpdateDatetime,
                //UpdateUserID = ent.AuditUpdateUserId
            };
        }

        public AddressData Map(Address ent)
        {
            return new AddressData
            {
                AddressKey = ent.AddressKey,
                AddressLine1 = ent.AddressLine1,
                AddressLine2 = ent.AddressLine2,
                AddressLine3 = ent.AddressLine3,
                AddressLine4 = ent.AddressLine4,
                AddressCity = ent.AddressCity,
                AddressStateProv = ent.AddressState,
                AddressPostalCode = ent.AddressPostalCode,
                AddressActiveFlg = ent.AddressActiveFlag ? 1 : 0,
                AddressCounty = ent.AddressCounty,
                AddressCountry = ent.AddressCountry,
                AddressDefaultFlg = ent.AddressDefaultFlag ? 1 : 0,
                AddressNotes = ent.AddressNotes,
                AddressTypeKey = (int)ent.AddressType,
                EntityKey = ent.EntityKey,
                EntityTypeKey = (int)ent.EntityType
            };
        }
    }
}
