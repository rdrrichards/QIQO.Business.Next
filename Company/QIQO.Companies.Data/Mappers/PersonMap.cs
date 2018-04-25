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
                    PersonKey = NullCheck<int>(record["person_key"]),
                    PersonCode = NullCheck<string>(record["person_code"]),
                    PersonFirstName = NullCheck<string>(record["person_first_name"]),
                    PersonMi = NullCheck<string>(record["person_mi"]),
                    PersonLastName = NullCheck<string>(record["person_last_name"]),
                    ParentPersonKey = NullCheck<int>(record["parent_person_key"]),
                    PersonDob = (DBNull.Value == record["person_dob"]) ? null : record["person_dob"] as DateTime?,
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"PersonMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(PersonData entity) => new List<SqlParameter>
            {
                BuildParam("@person_key", entity.PersonKey),
                BuildParam("@person_code", entity.PersonCode),
                BuildParam("@person_first_name", entity.PersonFirstName),
                BuildParam("@person_mi", entity.PersonMi),
                BuildParam("@person_last_name", entity.PersonLastName),
                BuildParam("@parent_person_key", entity.ParentPersonKey),
                BuildParam("@person_dob", entity.PersonDob),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(PersonData entity) => MapParamsForDelete(entity.PersonKey);

        public List<SqlParameter> MapParamsForDelete(int person_key) => new List<SqlParameter>
            {
                BuildParam("@person_key", person_key),
                GetOutParam()
            };
    }
}
