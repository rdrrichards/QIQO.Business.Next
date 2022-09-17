using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class PersonMap : MapperBase, IPersonMap
    {
        public PersonData Map(IDataReader record)
        {
            try
            {
                return new PersonData()
                {
                    PersonKey = NullCheck<int>(record["PersonKey"]),
                    PersonCode = NullCheck<string>(record["PersonCode"]),
                    PersonFirstName = NullCheck<string>(record["PersonFirstName"]),
                    PersonMi = NullCheck<string>(record["PersonMiddleInitial"]),
                    PersonLastName = NullCheck<string>(record["PersonLastName"]),
                    ParentPersonKey = NullCheck<int>(record["ParentPersonKey"]),
                    PersonDob = (DBNull.Value == record["PersonDob"]) ? null : record["PersonDob"] as DateTime?,
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"PersonMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(PersonData entity) => new List<SqlParameter>
            {
                BuildParam("@PersonKey", entity.PersonKey),
                BuildParam("@PersonCode", entity.PersonCode),
                BuildParam("@PersonFirstName", entity.PersonFirstName),
                BuildParam("@PersonMiddleInitial", entity.PersonMi),
                BuildParam("@PersonLastName", entity.PersonLastName),
                BuildParam("@ParentPersonKey", entity.ParentPersonKey),
                BuildParam("@PersonDob", entity.PersonDob),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(PersonData entity) => MapParamsForDelete(entity.PersonKey);

        public List<SqlParameter> MapParamsForDelete(int person_key) => new List<SqlParameter>
            {
                BuildParam("@PersonKey", person_key),
                GetOutParam()
            };
    }
}
