using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AttributeTypeMap : MapperBase, IAttributeTypeMap
    {
        public AttributeTypeData Map(IDataReader record)
        {
            try
            {
                return new AttributeTypeData()
                {
                    AttributeTypeKey = NullCheck<int>(record["attribute_type_key"]),
                    AttributeTypeCode = NullCheck<string>(record["attribute_type_code"]),
                    AttributeTypeName = NullCheck<string>(record["attribute_type_name"]),
                    AttributeTypeDesc = NullCheck<string>(record["attribute_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AttributeTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@attribute_type_key", entity.AttributeTypeKey),
                BuildParam("@attribute_type_code", entity.AttributeTypeCode),
                BuildParam("@attribute_type_name", entity.AttributeTypeName),
                BuildParam("@attribute_type_desc", entity.AttributeTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AttributeTypeData entity) => MapParamsForDelete(entity.AttributeTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@attribute_type_key", accountTypeKey),
                GetOutParam()
            };
    }
}
