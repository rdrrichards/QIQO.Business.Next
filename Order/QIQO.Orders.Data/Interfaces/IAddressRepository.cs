using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Orders.Data
{
    public interface IAddressRepository : IRepository<AddressData>
    {
        IEnumerable<AddressData> GetAll(int entity_key, int entity_type);
    }

}
