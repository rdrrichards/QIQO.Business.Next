using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AccountTypeMap : MapperBase, IAccountTypeMap
    {
        public AccountTypeData Map(IDataReader record)
        {
            try
            {
                return new AccountTypeData()
                {
                    AccountTypeKey = NullCheck<int>(record["account_type_key"]),
                    AccountTypeCode = NullCheck<string>(record["account_type_code"]),
                    AccountTypeName = NullCheck<string>(record["account_type_name"]),
                    AccountTypeDesc = NullCheck<string>(record["account_type_desc"]),
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

        public List<SqlParameter> MapParamsForUpsert(AccountTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@account_type_key", entity.AccountTypeKey),
                BuildParam("@account_type_code", entity.AccountTypeCode),
                BuildParam("@account_type_name", entity.AccountTypeName),
                BuildParam("@account_type_desc", entity.AccountTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AccountTypeData entity) => MapParamsForDelete(entity.AccountTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@account_type_key", accountTypeKey),
                GetOutParam()
            };
    }
}
