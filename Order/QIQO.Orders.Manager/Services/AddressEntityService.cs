using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class AddressEntityService : IAddressEntityService
    {
        public Address Map(AddressData ent) => new Address(ent);

        public AddressData Map(Address ent) => new AddressData
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
            EntityKey = ent.EntityKey
        };
    }
}
