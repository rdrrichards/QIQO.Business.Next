using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Accounts.Manager
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
