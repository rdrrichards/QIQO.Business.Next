using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Companies.Data
{
    public interface IAttributeRepository : IRepository<AttributeData>
    {
        IEnumerable<AttributeData> GetAll(int entityKey, int entity_type_key);
    }
    public interface IAttributeTypeRepository : IRepository<AttributeTypeData> { }
    public interface IAuditLogRepository : IRepository<AuditLogData> { }
}
