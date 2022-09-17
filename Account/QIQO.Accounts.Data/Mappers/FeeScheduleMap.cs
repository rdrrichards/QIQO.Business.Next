using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class FeeScheduleMap : MapperBase, IFeeScheduleMap
    {
        public FeeScheduleData Map(IDataReader record)
        {
            try
            {
                return new FeeScheduleData()
                {
                    FeeScheduleKey = NullCheck<int>(record["FeeScheduleKey"]),
                    CompanyKey = NullCheck<int>(record["CompanyKey"]),
                    AccountKey = NullCheck<int>(record["AccountKey"]),
                    ProductKey = NullCheck<int>(record["ProductKey"]),
                    FeeScheduleStartDate = NullCheck<DateTime>(record["FeeScheduleStartDate"]),
                    FeeScheduleEndDate = NullCheck<DateTime>(record["FeeScheduleEndDate"]),
                    FeeScheduleType = NullCheck<string>(record["FeeScheduleType"]),
                    FeeScheduleValue = NullCheck<decimal>(record["FeeScheduleValue"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"]),
                    ProductDesc = NullCheck<string>(record["ProductDescription"]),
                    ProductCode = NullCheck<string>(record["ProductCode"]),
                    AccountCode = NullCheck<string>(record["AccountCode"]),
                    AccountName = NullCheck<string>(record["AccountName"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"FeeScheduleMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(FeeScheduleData entity) => new List<SqlParameter>
            {
                BuildParam("@FeeScheduleKey", entity.FeeScheduleKey),
                BuildParam("@CompanyKey", entity.CompanyKey),
                BuildParam("@AccountKey", entity.AccountKey),
                BuildParam("@ProductKey", entity.ProductKey),
                BuildParam("@FeeScheduleStartDate", entity.FeeScheduleStartDate),
                BuildParam("@FeeScheduleEndDate", entity.FeeScheduleEndDate),
                BuildParam("@FeeScheduleType", entity.FeeScheduleType),
                BuildParam("@FeeScheduleValue", entity.FeeScheduleValue),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(FeeScheduleData entity) => MapParamsForDelete(entity.FeeScheduleKey);

        public List<SqlParameter> MapParamsForDelete(int fee_schedule_key) => new List<SqlParameter>
            {
                BuildParam("@FeeScheduleKey", fee_schedule_key),
                GetOutParam()
            };
    }
}
