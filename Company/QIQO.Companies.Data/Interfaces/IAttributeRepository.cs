using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Companies.Data
{
    public interface IAttributeRepository : IRepository<AttributeData>
    {
        IEnumerable<AttributeData> GetAll(int entity_key, int entity_type_key);
    }

}
