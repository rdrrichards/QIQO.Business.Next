using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Accounts.Data
{
    public interface IAttributeRepository : IRepository<AttributeData>
    {
        IEnumerable<AttributeData> GetAll(int entityKey, int entityTypeKey);
    }
    public interface IAttributeTypeRepository : IRepository<AttributeTypeData> { }
    public interface IAuditLogRepository : IRepository<AuditLogData> { }
}
