using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Companies.Data
{
    public interface IContactRepository : IRepository<ContactData>
    {
        IEnumerable<ContactData> GetAll(int entityKey, int entity_type_key);
    }
    public interface IContactTypeRepository : IRepository<ContactTypeData> { }
}
