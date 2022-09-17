using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceStatusMap : MapperBase, IInvoiceStatusMap
    {
        public InvoiceStatusData Map(IDataReader record)
        {
            try
            {
                return new InvoiceStatusData()
                {
                    InvoiceStatusKey = NullCheck<int>(record["InvoiceStatusKey"]),
                    InvoiceStatusCode = NullCheck<string>(record["InvoiceStatusCode"]),
                    InvoiceStatusName = NullCheck<string>(record["InvoiceStatusName"]),
                    InvoiceStatusType = NullCheck<string>(record["InvoiceStatusType"]),
                    InvoiceStatusDesc = NullCheck<string>(record["InvoiceStatusDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceStatusMap Exception occured: {ex.Message}", ex);
            }
        }
        public List<SqlParameter> MapParamsForUpsert(InvoiceStatusData entity) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceStatusKey", entity.InvoiceStatusKey),
                new SqlParameter("@InvoiceStatusCode", entity.InvoiceStatusCode),
                new SqlParameter("@InvoiceStatusName", entity.InvoiceStatusName),
                new SqlParameter("@InvoiceStatusType", entity.InvoiceStatusType),
                new SqlParameter("@InvoiceStatusDescription", entity.InvoiceStatusDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(InvoiceStatusData entity) => MapParamsForDelete(entity.InvoiceStatusKey);

        public List<SqlParameter> MapParamsForDelete(int invoice_status_key) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceStatusKey", invoice_status_key),
                GetOutParam()
            };
    }
}
