using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class AddressTypeEntityService : IAddressTypeEntityService
    {
        public AddressType Map(AddressTypeData commentData) => new AddressType(commentData);
        public AddressTypeData Map(AddressType comment) => new AddressTypeData()
        {
            AddressTypeKey = comment.AddressTypeKey,
            AddressTypeCode = comment.AddressTypeCode,
            AddressTypeName = comment.AddressTypeName,
            AddressTypeDesc = comment.AddressTypeDesc
        };
    }
}
