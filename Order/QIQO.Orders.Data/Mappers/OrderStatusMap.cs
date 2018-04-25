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
                    OrderStatusKey = NullCheck<int>(record["order_status_key"]),
                    OrderStatusCode = NullCheck<string>(record["order_status_code"]),
                    OrderStatusName = NullCheck<string>(record["order_status_name"]),
                    OrderStatusType = NullCheck<string>(record["order_status_type"]),
                    OrderStatusDesc = NullCheck<string>(record["order_status_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderStatusMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderStatusData entity) => new List<SqlParameter>
            {
                new SqlParameter("@order_status_key", entity.OrderStatusKey),
                new SqlParameter("@order_status_code", entity.OrderStatusCode),
                new SqlParameter("@order_status_name", entity.OrderStatusName),
                new SqlParameter("@order_status_type", entity.OrderStatusType),
                new SqlParameter("@order_status_desc", entity.OrderStatusDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderStatusData entity) => MapParamsForDelete(entity.OrderStatusKey);

        public List<SqlParameter> MapParamsForDelete(int order_status_key) => new List<SqlParameter>
            {
                new SqlParameter("@order_status_key", order_status_key),
                GetOutParam()
            };
    }
}
