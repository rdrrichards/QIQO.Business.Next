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
                    AccountKey = NullCheck<int>(record["AccountKey"]),
                    CompanyKey = NullCheck<int>(record["CompanyKey"]),
                    AccountTypeKey = NullCheck<int>(record["AccountTypeKey"]),
                    AccountCode = NullCheck<string>(record["AccountCode"]),
                    AccountName = NullCheck<string>(record["AccountName"]),
                    AccountDesc = NullCheck<string>(record["AccountDescription"]),
                    AccountDba = NullCheck<string>(record["AccountDba"]),
                    AccountStartDate = NullCheck<DateTime>(record["AccountStartDate"]),
                    AccountEndDate = NullCheck<DateTime>(record["AccountEndDate"]),
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

        public List<SqlParameter> MapParamsForUpsert(AccountData entity) => new List<SqlParameter>
            {
                BuildParam("@AccountKey", entity.AccountKey),
                BuildParam("@CompanyKey", entity.CompanyKey),
                BuildParam("@AccountTypeKey", entity.AccountTypeKey),
                BuildParam("@AccountCode", entity.AccountCode),
                BuildParam("@AccountName", entity.AccountName),
                BuildParam("@AccountDescription", entity.AccountDesc),
                BuildParam("@AccountDba", entity.AccountDba),
                BuildParam("@AccountStartDate", entity.AccountStartDate),
                BuildParam("@AccountEndDate", entity.AccountEndDate),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AccountData entity) => MapParamsForDelete(entity.AccountKey);

        public List<SqlParameter> MapParamsForDelete(int account_key) => new List<SqlParameter>
            {
                BuildParam("@AccountKey", account_key),
                GetOutParam()
            };
    }
}
