using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class PersonTypeMap : MapperBase, IPersonTypeMap
    {
        public PersonTypeData Map(IDataReader record)
        {
            try
            {
                return new PersonTypeData()
                {
                    PersonTypeKey = NullCheck<int>(record["person_type_key"]),
                    PersonTypeCode = NullCheck<string>(record["person_type_code"]),
                    PersonTypeName = NullCheck<string>(record["person_type_name"]),
                    PersonTypeDesc = NullCheck<string>(record["person_type_desc"]),
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

        public List<SqlParameter> MapParamsForUpsert(PersonTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@person_type_key", entity.PersonTypeKey),
                BuildParam("@person_type_code", entity.PersonTypeCode),
                BuildParam("@person_type_name", entity.PersonTypeName),
                BuildParam("@person_type_desc", entity.PersonTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(PersonTypeData entity) => MapParamsForDelete(entity.PersonTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@person_type_key", accountTypeKey),
                GetOutParam()
            };
    }
}
