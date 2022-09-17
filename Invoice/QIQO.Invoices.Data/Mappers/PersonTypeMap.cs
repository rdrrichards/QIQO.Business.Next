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
                    PersonTypeKey = NullCheck<int>(record["PersonTypeKey"]),
                    PersonTypeCode = NullCheck<string>(record["PersonTypeCode"]),
                    PersonTypeName = NullCheck<string>(record["PersonTypeName"]),
                    PersonTypeDesc = NullCheck<string>(record["PersonTypeDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(PersonTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@PersonTypeKey", entity.PersonTypeKey),
                BuildParam("@PersonTypeCode", entity.PersonTypeCode),
                BuildParam("@PersonTypeName", entity.PersonTypeName),
                BuildParam("@PersonTypeDescription", entity.PersonTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(PersonTypeData entity) => MapParamsForDelete(entity.PersonTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@PersonTypeKey", accountTypeKey),
                GetOutParam()
            };
    }
}
