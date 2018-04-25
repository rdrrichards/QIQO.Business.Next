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
                    InvoiceStatusKey = NullCheck<int>(record["invoice_status_key"]),
                    InvoiceStatusCode = NullCheck<string>(record["invoice_status_code"]),
                    InvoiceStatusName = NullCheck<string>(record["invoice_status_name"]),
                    InvoiceStatusType = NullCheck<string>(record["invoice_status_type"]),
                    InvoiceStatusDesc = NullCheck<string>(record["invoice_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceStatusMap Exception occured: {ex.Message}", ex);
            }
        }
        public List<SqlParameter> MapParamsForUpsert(InvoiceStatusData entity) => new List<SqlParameter>
            {
                new SqlParameter("@invoice_status_key", entity.InvoiceStatusKey),
                new SqlParameter("@invoice_status_code", entity.InvoiceStatusCode),
                new SqlParameter("@invoice_status_name", entity.InvoiceStatusName),
                new SqlParameter("@invoice_status_type", entity.InvoiceStatusType),
                new SqlParameter("@invoice_status_desc", entity.InvoiceStatusDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(InvoiceStatusData entity) => MapParamsForDelete(entity.InvoiceStatusKey);

        public List<SqlParameter> MapParamsForDelete(int invoice_status_key) => new List<SqlParameter>
            {
                new SqlParameter("@invoice_status_key", invoice_status_key),
                GetOutParam()
            };
    }
}
