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
                    AttributeKey = NullCheck<int>(record["AttributeKey"]),
                    EntityKey = NullCheck<int>(record["EntityKey"]),
                    EntityTypeKey = NullCheck<int>(record["EntityTypeKey"]),
                    AttributeTypeKey = NullCheck<int>(record["AttributeTypeKey"]),
                    AttributeValue = NullCheck<string>(record["AttributeValue"]),
                    AttributeDataTypeKey = NullCheck<int>(record["AttributeDataTypeKey"]),
                    AttributeDisplayFormat = NullCheck<string>(record["AttributeDisplayFormat"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AttributeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AttributeData entity) => new List<SqlParameter>
            {
                BuildParam("@AttributeKey", entity.AttributeKey),
                BuildParam("@EntityKey", entity.EntityKey),
                BuildParam("@EntityTypeKey", entity.EntityTypeKey),
                BuildParam("@AttributeTypeKey", entity.AttributeTypeKey),
                BuildParam("@AttributeValue", entity.AttributeValue),
                BuildParam("@AttributeDataTypeKey", entity.AttributeDataTypeKey),
                BuildParam("@AttributeDisplayFormat", entity.AttributeDisplayFormat),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AttributeData entity) => MapParamsForDelete(entity.AttributeKey);

        public List<SqlParameter> MapParamsForDelete(int attribute_key) => new List<SqlParameter>
            {
                BuildParam("@AttributeKey", attribute_key),
                GetOutParam()
            };
    }
}
