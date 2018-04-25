using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class ContactTypeMap : MapperBase, IContactTypeMap
    {
        public ContactTypeData Map(IDataReader record)
        {
            try
            {
                return new ContactTypeData()
                {
                    ContactTypeKey = NullCheck<int>(record["contact_type_key"]),
                    ContactTypeCode = NullCheck<string>(record["contact_type_code"]),
                    ContactTypeName = NullCheck<string>(record["contact_type_name"]),
                    ContactTypeDesc = NullCheck<string>(record["contact_type_desc"]),
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

        public List<SqlParameter> MapParamsForUpsert(ContactTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@contact_type_key", entity.ContactTypeKey),
                BuildParam("@contact_type_code", entity.ContactTypeCode),
                BuildParam("@contact_type_name", entity.ContactTypeName),
                BuildParam("@contact_type_desc", entity.ContactTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ContactTypeData entity) => MapParamsForDelete(entity.ContactTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@contact_type_key", accountTypeKey),
                GetOutParam()
            };
    }
}
