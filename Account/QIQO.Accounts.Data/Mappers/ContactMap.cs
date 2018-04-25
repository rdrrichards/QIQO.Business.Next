using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class ContactMap : MapperBase, IContactMap
    {
        public ContactData Map(IDataReader record)
        {
            try
            {
                return new ContactData()
                {
                    ContactKey = NullCheck<int>(record["contact_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    ContactTypeKey = NullCheck<int>(record["contact_type_key"]),
                    ContactValue = NullCheck<string>(record["contact_value"]),
                    ContactDefaultFlg = NullCheck<int>(record["contact_default_flg"]),
                    ContactActiveFlg = NullCheck<int>(record["contact_active_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"]),
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ContactMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ContactData entity) => new List<SqlParameter>
            {
                BuildParam("@contact_key", entity.ContactKey),
                BuildParam("@entity_key", entity.EntityKey),
                BuildParam("@entity_type_key", entity.EntityTypeKey),
                BuildParam("@contact_type_key", entity.ContactTypeKey),
                BuildParam("@contact_value", entity.ContactValue),
                BuildParam("@contact_default_flg", entity.ContactDefaultFlg),
                BuildParam("@contact_active_flg", entity.ContactActiveFlg),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ContactData entity) => MapParamsForDelete(entity.ContactKey);

        public List<SqlParameter> MapParamsForDelete(int contact_key) => new List<SqlParameter>
            {
                BuildParam("@contact_key", contact_key),
                GetOutParam()
            };
    }
}
