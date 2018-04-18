using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Invoices.Data
{
    public interface IAddressRepository : IRepository<AddressData>
    {
        IEnumerable<AddressData> GetAll(int entity_key, int entity_type);
    }

}
