using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
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
