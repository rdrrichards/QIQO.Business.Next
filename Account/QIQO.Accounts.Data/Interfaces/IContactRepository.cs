using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Accounts.Data
{
    public interface IContactRepository : IRepository<ContactData>
    {
        IEnumerable<ContactData> GetAll(int entityKey, int entityTypeKey);
    }
    public interface IContactTypeRepository : IRepository<ContactTypeData> { }
}
