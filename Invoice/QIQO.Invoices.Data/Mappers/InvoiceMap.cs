using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceMap : MapperBase, IInvoiceMap
    {
        public InvoiceData Map(IDataReader record)
        {
            try
            {
                return new InvoiceData()
                {
                    InvoiceKey = NullCheck<int>(record["InvoiceKey"]),
                    FromEntityKey = NullCheck<int>(record["FromEntityKey"]),
                    AccountKey = NullCheck<int>(record["AccountKey"]),
                    AccountContactKey = NullCheck<int>(record["AccountContactKey"]),
                    InvoiceNum = NullCheck<string>(record["InvoiceNumber"]),
                    InvoiceEntryDate = NullCheck<DateTime>(record["InvoiceEntryDate"]),
                    OrderEntryDate = NullCheck<DateTime>(record["OrderEntryDate"]),
                    InvoiceStatusKey = NullCheck<int>(record["InvoiceStatusKey"]),
                    InvoiceStatusDate = NullCheck<DateTime>(record["InvoiceStatusKey"]),
                    OrderShipDate = (DBNull.Value == record["OrderShipDate"]) ? null : record["OrderShipDate"] as DateTime?,
                    AccountRepKey = NullCheck<int>(record["AccountRepKey"]),
                    SalesRepKey = NullCheck<int>(record["SalesRepKey"]),
                    InvoiceCompleteDate = (DBNull.Value == record["InvoiceCompleteDate"]) ? null : record["InvoiceCompleteDate"] as DateTime?,
                    InvoiceValueSum = NullCheck<decimal>(record["InvoiceValueSum"]),
                    InvoiceItemCount = NullCheck<int>(record["InvoiceItemCount"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceMap Exception occured: {ex.Message}", ex);
            }
        }
        public List<SqlParameter> MapParamsForUpsert(InvoiceData entity) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceKey", entity.InvoiceKey),
                new SqlParameter("@FromEntityKey", entity.FromEntityKey),
                new SqlParameter("@AccountKey", entity.AccountKey),
                new SqlParameter("@AccountContactKey", entity.AccountContactKey),
                new SqlParameter("@invoice_num", entity.InvoiceNum),
                new SqlParameter("@InvoiceEntryDate", entity.InvoiceEntryDate),
                new SqlParameter("@OrderEntryDate", entity.OrderEntryDate),
                new SqlParameter("@InvoiceStatusKey", entity.InvoiceStatusKey),
                new SqlParameter("@InvoiceStatusKey", entity.InvoiceStatusDate),
                new SqlParameter("@OrderShipDate", entity.OrderShipDate),
                new SqlParameter("@AccountRepKey", entity.AccountRepKey),
                new SqlParameter("@SalesRepKey", entity.SalesRepKey),
                new SqlParameter("@InvoiceCompleteDate", entity.InvoiceCompleteDate),
                new SqlParameter("@InvoiceValueSum", entity.InvoiceValueSum),
                new SqlParameter("@InvoiceItemCount", entity.InvoiceItemCount),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(InvoiceData entity) => MapParamsForDelete(entity.InvoiceKey);

        public List<SqlParameter> MapParamsForDelete(int invoice_key) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceKey", invoice_key),
                GetOutParam()
            };
    }
}
