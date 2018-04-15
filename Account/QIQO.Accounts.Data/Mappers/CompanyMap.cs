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

        public List<SqlParameter> MapParamsForUpsert(CompanyData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@company_key", entity.CompanyKey));
            sql_params.Add(BuildParam("@company_code", entity.CompanyCode));
            sql_params.Add(BuildParam("@company_name", entity.CompanyName));
            sql_params.Add(BuildParam("@company_desc", entity.CompanyDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(CompanyData entity)
        {
            return MapParamsForDelete(entity.CompanyKey);
        }

        public List<SqlParameter> MapParamsForDelete(int company_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@company_key", company_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    }
}
