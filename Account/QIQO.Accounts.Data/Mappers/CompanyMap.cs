using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class CompanyMap : MapperBase, ICompanyMap
    {
        public CompanyData Map(IDataReader record)
        {
            try
            {
                return new CompanyData()
                {
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    CompanyCode = NullCheck<string>(record["company_code"]),
                    CompanyName = NullCheck<string>(record["company_name"]),
                    CompanyDesc = NullCheck<string>(record["company_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CompanyMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(CompanyData entity) => new List<SqlParameter>
            {
                BuildParam("@company_key", entity.CompanyKey),
                BuildParam("@company_code", entity.CompanyCode),
                BuildParam("@company_name", entity.CompanyName),
                BuildParam("@company_desc", entity.CompanyDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CompanyData entity) => MapParamsForDelete(entity.CompanyKey);

        public List<SqlParameter> MapParamsForDelete(int company_key) => new List<SqlParameter>
            {
                BuildParam("@company_key", company_key),
                GetOutParam()
            };
    }
}
