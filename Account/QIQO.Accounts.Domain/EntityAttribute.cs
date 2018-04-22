using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class EntityAttribute : IModel
    {
        public EntityAttribute(AttributeData entityAttributeData)
        {
            AttributeKey = entityAttributeData.AttributeKey;
            EntityKey = entityAttributeData.EntityKey;
            EntityType = (QIQOEntityType)entityAttributeData.EntityTypeKey;
            AttributeDataType = (QIQOAttributeDataType)entityAttributeData.AttributeDataTypeKey;
            AttributeDataTypeKey = entityAttributeData.AttributeTypeKey;
            AttributeValue = entityAttributeData.AttributeValue;
            AttributeDisplayFormat = entityAttributeData.AttributeDisplayFormat;
            AddedDateTime = entityAttributeData.AuditAddDatetime;
            AddedUserID = entityAttributeData.AuditAddUserId;
            UpdateDateTime = entityAttributeData.AuditUpdateDatetime;
            UpdateUserID = entityAttributeData.AuditUpdateUserId;
        }
        public int AttributeKey { get; private set; }
        public int EntityKey { get; private set; }
        public QIQOEntityType EntityType { get; private set; } = QIQOEntityType.Account;
        // public EntityType EntityTypeData { get; private set; }
        // public QIQOAttributeType AttributeType { get; private set; } = QIQOAttributeType.AccountContact_CNCT_MAIN;
        // public AttributeType AttributeTypeData { get; private set; }
        public string AttributeValue { get; private set; }
        public int AttributeDataTypeKey { get; private set; }
        public QIQOAttributeDataType AttributeDataType { get; private set; } = QIQOAttributeDataType.String;
        public string AttributeDisplayFormat { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
