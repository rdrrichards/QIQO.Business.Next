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
                    CompanyKey = NullCheck<int>(record["CompanyKey"]),
                    CompanyCode = NullCheck<string>(record["CompanyCode"]),
                    CompanyName = NullCheck<string>(record["CompanyName"]),
                    CompanyDesc = NullCheck<string>(record["CompanyDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CompanyMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(CompanyData entity) => new List<SqlParameter>
            {
                BuildParam("@CompanyKey", entity.CompanyKey),
                BuildParam("@CompanyCode", entity.CompanyCode),
                BuildParam("@CompanyName", entity.CompanyName),
                BuildParam("@CompanyDescription", entity.CompanyDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CompanyData entity) => MapParamsForDelete(entity.CompanyKey);

        public List<SqlParameter> MapParamsForDelete(int company_key) => new List<SqlParameter>
            {
                BuildParam("@CompanyKey", company_key),
                GetOutParam()
            };
    }
}
