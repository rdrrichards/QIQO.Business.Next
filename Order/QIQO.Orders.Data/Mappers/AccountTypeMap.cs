using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class AccountTypeMap : MapperBase, IAccountTypeMap
    {
        public AccountTypeData Map(IDataReader record)
        {
            try
            {
                return new AccountTypeData()
                {
                    AccountTypeKey = NullCheck<int>(record["AccountTypeKey"]),
                    AccountTypeCode = NullCheck<string>(record["AccountTypeCode"]),
                    AccountTypeName = NullCheck<string>(record["AccountTypeName"]),
                    AccountTypeDesc = NullCheck<string>(record["AccountTypeDescription"]),
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

        public List<SqlParameter> MapParamsForUpsert(AccountTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@AccountTypeKey", entity.AccountTypeKey),
                BuildParam("@AccountTypeCode", entity.AccountTypeCode),
                BuildParam("@AccountTypeName", entity.AccountTypeName),
                BuildParam("@AccountTypeDescription", entity.AccountTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AccountTypeData entity) => MapParamsForDelete(entity.AccountTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@AccountTypeKey", accountTypeKey),
                GetOutParam()
            };
    }
}
