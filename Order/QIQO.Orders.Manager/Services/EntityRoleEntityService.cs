using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class EntityRoleEntityService : IEntityRoleEntityService
    {
        public EntityRole Map(EntityRoleData commentData) => new EntityRole(commentData);
        public EntityRoleData Map(EntityRole comment) => new EntityRoleData()
        {
            EntityRoleKey = comment.EntityRoleKey,
            EntityRoleCode = comment.EntityRoleCode,
            EntityRoleName = comment.EntityRoleName,
            EntityRoleDesc = comment.EntityRoleDesc
        };
    }
}
