using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderStatusMap : MapperBase, IOrderStatusMap
    { // OrderStatusMap class opener
        public OrderStatusData Map(IDataReader record)
        {
            try
            {
                return new OrderStatusData()
                {
                    OrderStatusKey = NullCheck<int>(record["OrderStatusKey"]),
                    OrderStatusCode = NullCheck<string>(record["OrderStatusCode"]),
                    OrderStatusName = NullCheck<string>(record["OrderStatusName"]),
                    OrderStatusType = NullCheck<string>(record["OrderStatusType"]),
                    OrderStatusDesc = NullCheck<string>(record["OrderStatusDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderStatusData entity) => new List<SqlParameter>
            {
                new SqlParameter("@OrderStatusKey", entity.OrderStatusKey),
                new SqlParameter("@OrderStatusCode", entity.OrderStatusCode),
                new SqlParameter("@OrderStatusName", entity.OrderStatusName),
                new SqlParameter("@OrderStatusType", entity.OrderStatusType),
                new SqlParameter("@OrderStatusDesc", entity.OrderStatusDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderStatusData entity) => MapParamsForDelete(entity.OrderStatusKey);

        public List<SqlParameter> MapParamsForDelete(int order_status_key) => new List<SqlParameter>
            {
                new SqlParameter("@OrderStatusKey", order_status_key),
                GetOutParam()
            };
    }
}
