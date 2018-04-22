using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class AttributeEntityService : IAttributeEntityService
    {
        public EntityAttribute Map(AttributeData ent) => new EntityAttribute(ent);

        public AttributeData Map(EntityAttribute ent) => new AttributeData()
        {
            AttributeKey = ent.AttributeKey,
            EntityKey = ent.EntityKey,
            EntityTypeKey = (int)ent.EntityType,
            // AttributeTypeKey = (int)ent.AttributeType,
            AttributeValue = ent.AttributeValue,
            AttributeDataTypeKey = ent.AttributeDataTypeKey,
            AttributeDisplayFormat = ent.AttributeDisplayFormat
        };
    }
}
