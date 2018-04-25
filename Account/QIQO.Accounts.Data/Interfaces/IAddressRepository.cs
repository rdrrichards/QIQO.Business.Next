using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Accounts.Data
{
    public interface IAddressRepository : IRepository<AddressData>
    {
        IEnumerable<AddressData> GetAll(int entityKey, int entity_type);
    }
    public interface IAddressTypeRepository : IRepository<AddressTypeData> { }
    public interface IAddressPostalRepository : IRepository<AddressPostalData> { }
}
