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
                    ContactTypeKey = NullCheck<int>(record["ContactTypeKey"]),
                    ContactTypeCode = NullCheck<string>(record["ContactTypeCode"]),
                    ContactTypeName = NullCheck<string>(record["ContactTypeName"]),
                    ContactTypeDesc = NullCheck<string>(record["ContactTypeDescription"]),
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

        public List<SqlParameter> MapParamsForUpsert(ContactTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@ContactTypeKey", entity.ContactTypeKey),
                BuildParam("@ContactTypeCode", entity.ContactTypeCode),
                BuildParam("@ContactTypeName", entity.ContactTypeName),
                BuildParam("@ContactTypeDescription", entity.ContactTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ContactTypeData entity) => MapParamsForDelete(entity.ContactTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@ContactTypeKey", accountTypeKey),
                GetOutParam()
            };
    }
}
