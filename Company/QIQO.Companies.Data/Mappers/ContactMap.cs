using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class ContactMap : MapperBase, IContactMap
    {
        public ContactData Map(IDataReader record)
        {
            try
            {
                return new ContactData()
                {
                    ContactKey = NullCheck<int>(record["ContactKey"]),
                    EntityKey = NullCheck<int>(record["EntityKey"]),
                    EntityTypeKey = NullCheck<int>(record["EntityTypeKey"]),
                    ContactTypeKey = NullCheck<int>(record["ContactTypeKey"]),
                    ContactValue = NullCheck<string>(record["ContactValue"]),
                    ContactDefaultFlg = NullCheck<int>(record["ContactDefaultFlag"]),
                    ContactActiveFlg = NullCheck<int>(record["ContactActiveFlag"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"]),
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ContactMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ContactData entity) => new List<SqlParameter>
            {
                BuildParam("@ContactKey", entity.ContactKey),
                BuildParam("@EntityKey", entity.EntityKey),
                BuildParam("@EntityTypeKey", entity.EntityTypeKey),
                BuildParam("@ContactTypeKey", entity.ContactTypeKey),
                BuildParam("@ContactValue", entity.ContactValue),
                BuildParam("@ContactDefaultFlag", entity.ContactDefaultFlg),
                BuildParam("@ContactActiveFlag", entity.ContactActiveFlg),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ContactData entity) => MapParamsForDelete(entity.ContactKey);

        public List<SqlParameter> MapParamsForDelete(int contact_key) => new List<SqlParameter>
            {
                BuildParam("@ContactKey", contact_key),
                GetOutParam()
            };
    }
}
