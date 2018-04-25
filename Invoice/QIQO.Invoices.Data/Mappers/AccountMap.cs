using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class AccountMap : MapperBase, IAccountMap
    {
        public AccountData Map(IDataReader record)
        {
            try
            {
                return new AccountData()
                {
                    AccountKey = NullCheck<int>(record["account_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AccountTypeKey = NullCheck<int>(record["account_type_key"]),
                    AccountCode = NullCheck<string>(record["account_code"]),
                    AccountName = NullCheck<string>(record["account_name"]),
                    AccountDesc = NullCheck<string>(record["account_desc"]),
                    AccountDba = NullCheck<string>(record["account_dba"]),
                    AccountStartDate = NullCheck<DateTime>(record["account_start_date"]),
                    AccountEndDate = NullCheck<DateTime>(record["account_end_date"]),
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

        public List<SqlParameter> MapParamsForUpsert(AccountData entity) => new List<SqlParameter>
            {
                BuildParam("@account_key", entity.AccountKey),
                BuildParam("@company_key", entity.CompanyKey),
                BuildParam("@account_type_key", entity.AccountTypeKey),
                BuildParam("@account_code", entity.AccountCode),
                BuildParam("@account_name", entity.AccountName),
                BuildParam("@account_desc", entity.AccountDesc),
                BuildParam("@account_dba", entity.AccountDba),
                BuildParam("@account_start_date", entity.AccountStartDate),
                BuildParam("@account_end_date", entity.AccountEndDate),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AccountData entity) => MapParamsForDelete(entity.AccountKey);

        public List<SqlParameter> MapParamsForDelete(int account_key) => new List<SqlParameter>
            {
                BuildParam("@account_key", account_key),
                GetOutParam()
            };
    }
}
