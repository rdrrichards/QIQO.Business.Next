using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AttributeMap : MapperBase, IAttributeMap
    {
        public AttributeData Map(IDataReader record)
        {
            try
            {
                return new AttributeData()
                {
                    AttributeKey = NullCheck<int>(record["attribute_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    AttributeTypeKey = NullCheck<int>(record["attribute_type_key"]),
                    AttributeValue = NullCheck<string>(record["attribute_value"]),
                    AttributeDataTypeKey = NullCheck<int>(record["attribute_data_type_key"]),
                    AttributeDisplayFormat = NullCheck<string>(record["attribute_display_format"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AttributeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AttributeData entity) => new List<SqlParameter>
            {
                BuildParam("@attribute_key", entity.AttributeKey),
                BuildParam("@entity_key", entity.EntityKey),
                BuildParam("@entity_type_key", entity.EntityTypeKey),
                BuildParam("@attribute_type_key", entity.AttributeTypeKey),
                BuildParam("@attribute_value", entity.AttributeValue),
                BuildParam("@attribute_data_type_key", entity.AttributeDataTypeKey),
                BuildParam("@attribute_display_format", entity.AttributeDisplayFormat),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AttributeData entity) => MapParamsForDelete(entity.AttributeKey);

        public List<SqlParameter> MapParamsForDelete(int attribute_key) => new List<SqlParameter>
            {
                BuildParam("@attribute_key", attribute_key),
                GetOutParam()
            };
    }
}
