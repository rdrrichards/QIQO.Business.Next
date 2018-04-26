using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Accounts.Manager
{
    public class EntityTypeEntityService : IEntityTypeEntityService
    {
        public EntityType Map(EntityTypeData commentData) => new EntityType(commentData);
        public EntityTypeData Map(EntityType comment) => new EntityTypeData()
        {
            EntityTypeKey = comment.EntityTypeKey,
            EntityTypeCode = comment.EntityTypeCode,
            EntityTypeName = comment.EntityTypeName,
            EntityTypeDesc = comment.EntityTypeDesc
        };
    }
}
