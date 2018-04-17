using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
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

        public List<SqlParameter> MapParamsForUpsert(AttributeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@attribute_key", entity.AttributeKey));
            sql_params.Add(BuildParam("@entity_key", entity.EntityKey));
            sql_params.Add(BuildParam("@entity_type_key", entity.EntityTypeKey));
            sql_params.Add(BuildParam("@attribute_type_key", entity.AttributeTypeKey));
            sql_params.Add(BuildParam("@attribute_value", entity.AttributeValue));
            sql_params.Add(BuildParam("@attribute_data_type_key", entity.AttributeDataTypeKey));
            sql_params.Add(BuildParam("@attribute_display_format", entity.AttributeDisplayFormat));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AttributeData entity)
        {
            return MapParamsForDelete(entity.AttributeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int attribute_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@attribute_key", attribute_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    }
}
