using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderHeaderMap : MapperBase, IOrderHeaderMap
    { // OrderHeaderMap class opener
        public OrderHeaderData Map(IDataReader record)
        {
            try
            {
                return new OrderHeaderData()
                {
                    OrderKey = NullCheck<int>(record["OrderKey"]),
                    AccountKey = NullCheck<int>(record["AccountKey"]),
                    AccountContactKey = NullCheck<int>(record["AccountContactKey"]),
                    OrderNum = NullCheck<string>(record["OrderNumber"]),
                    OrderEntryDate = NullCheck<DateTime>(record["OrderEntryDate"]),
                    OrderStatusKey = NullCheck<int>(record["OrderStatusKey"]),
                    OrderStatusDate = NullCheck<DateTime>(record["order_status_date"]),
                    OrderShipDate = (DBNull.Value == record["OrderShipDate"]) ? null : record["OrderShipDate"] as DateTime?,
                    AccountRepKey = NullCheck<int>(record["AccountRepKey"]),
                    OrderCompleteDate = (DBNull.Value == record["OrderCompleteDate"]) ? null : record["OrderCompleteDate"] as DateTime?,
                    OrderValueSum = NullCheck<decimal>(record["order_value_sum"]),
                    OrderItemCount = NullCheck<int>(record["OrderValueSum"]),
                    DeliverByDate = (DBNull.Value == record["DeliverByDate"]) ? null : record["DeliverByDate"] as DateTime?,
                    SalesRepKey = NullCheck<int>(record["SalesRepKey"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderHeaderMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderHeaderData entity) => new List<SqlParameter>
            {
                new SqlParameter("@OrderKey", entity.OrderKey),
                new SqlParameter("@AccountKey", entity.AccountKey),
                new SqlParameter("@AccountContactKey", entity.AccountContactKey),
                new SqlParameter("@OrderNumber", entity.OrderNum),
                new SqlParameter("@OrderEntryDate", entity.OrderEntryDate),
                new SqlParameter("@OrderStatusKey", entity.OrderStatusKey),
                new SqlParameter("@order_status_date", entity.OrderStatusDate),
                new SqlParameter("@OrderShipDate", entity.OrderShipDate),
                new SqlParameter("@AccountRepKey", entity.AccountRepKey),
                new SqlParameter("@OrderCompleteDate", entity.OrderCompleteDate),
                new SqlParameter("@order_value_sum", entity.OrderValueSum),
                new SqlParameter("@OrderValueSum", entity.OrderItemCount),
                new SqlParameter("@DeliverByDate", entity.DeliverByDate),
                new SqlParameter("@SalesRepKey", entity.SalesRepKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderHeaderData entity) => MapParamsForDelete(entity.OrderKey);

        public List<SqlParameter> MapParamsForDelete(int order_key) => new List<SqlParameter>
            {
                new SqlParameter("@OrderKey", order_key),
                GetOutParam()
            };
    }
}
