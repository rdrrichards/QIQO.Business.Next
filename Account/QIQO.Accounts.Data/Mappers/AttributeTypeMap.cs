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
                    AttributeTypeKey = NullCheck<int>(record["AttributeTypeKey"]),
                    AttributeTypeCode = NullCheck<string>(record["AttributeTypeCode"]),
                    AttributeTypeName = NullCheck<string>(record["AttributeTypeName"]),
                    AttributeTypeDesc = NullCheck<string>(record["AttributeTypeDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"{nameof(AttributeTypeMap)} Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AttributeTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@AttributeTypeKey", entity.AttributeTypeKey),
                BuildParam("@AttributeTypeCode", entity.AttributeTypeCode),
                BuildParam("@AttributeTypeName", entity.AttributeTypeName),
                BuildParam("@AttributeTypeDescription", entity.AttributeTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AttributeTypeData entity) => MapParamsForDelete(entity.AttributeTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@AttributeTypeKey", accountTypeKey),
                GetOutParam()
            };
    }
}
