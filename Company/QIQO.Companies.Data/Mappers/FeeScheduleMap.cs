using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class FeeScheduleMap : MapperBase, IFeeScheduleMap
    {
        public FeeScheduleData Map(IDataReader record)
        {
            try
            {
                return new FeeScheduleData()
                {
                    FeeScheduleKey = NullCheck<int>(record["fee_schedule_key"]),
                    CompanyKey = NullCheck<int>(record["company_key"]),
                    AccountKey = NullCheck<int>(record["account_key"]),
                    ProductKey = NullCheck<int>(record["product_key"]),
                    FeeScheduleStartDate = NullCheck<DateTime>(record["fee_schedule_start_date"]),
                    FeeScheduleEndDate = NullCheck<DateTime>(record["fee_schedule_end_date"]),
                    FeeScheduleType = NullCheck<string>(record["fee_schedule_type"]),
                    FeeScheduleValue = NullCheck<decimal>(record["fee_schedule_value"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    ProductCode = NullCheck<string>(record["product_code"]),
                    AccountCode = NullCheck<string>(record["account_code"]),
                    AccountName = NullCheck<string>(record["account_name"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"FeeScheduleMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(FeeScheduleData entity) => new List<SqlParameter>
            {
                BuildParam("@fee_schedule_key", entity.FeeScheduleKey),
                BuildParam("@company_key", entity.CompanyKey),
                BuildParam("@account_key", entity.AccountKey),
                BuildParam("@product_key", entity.ProductKey),
                BuildParam("@fee_schedule_start_date", entity.FeeScheduleStartDate),
                BuildParam("@fee_schedule_end_date", entity.FeeScheduleEndDate),
                BuildParam("@fee_schedule_type", entity.FeeScheduleType),
                BuildParam("@fee_schedule_value", entity.FeeScheduleValue),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(FeeScheduleData entity) => MapParamsForDelete(entity.FeeScheduleKey);

        public List<SqlParameter> MapParamsForDelete(int fee_schedule_key) => new List<SqlParameter>
            {
                BuildParam("@fee_schedule_key", fee_schedule_key),
                GetOutParam()
            };
    }
}
