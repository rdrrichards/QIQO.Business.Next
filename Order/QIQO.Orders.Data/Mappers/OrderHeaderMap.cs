﻿using QIQO.Business.Core;
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
                    OrderKey = NullCheck<int>(record["order_key"]),
                    AccountKey = NullCheck<int>(record["account_key"]),
                    AccountContactKey = NullCheck<int>(record["account_contact_key"]),
                    OrderNum = NullCheck<string>(record["order_num"]),
                    OrderEntryDate = NullCheck<DateTime>(record["order_entry_date"]),
                    OrderStatusKey = NullCheck<int>(record["order_status_key"]),
                    OrderStatusDate = NullCheck<DateTime>(record["order_status_date"]),
                    OrderShipDate = (DBNull.Value == record["order_ship_date"]) ? null : record["order_ship_date"] as DateTime?,
                    AccountRepKey = NullCheck<int>(record["account_rep_key"]),
                    OrderCompleteDate = (DBNull.Value == record["order_complete_date"]) ? null : record["order_complete_date"] as DateTime?,
                    OrderValueSum = NullCheck<decimal>(record["order_value_sum"]),
                    OrderItemCount = NullCheck<int>(record["order_item_count"]),
                    DeliverByDate = (DBNull.Value == record["deliver_by_date"]) ? null : record["deliver_by_date"] as DateTime?,
                    SalesRepKey = NullCheck<int>(record["sales_rep_key"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderHeaderMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderHeaderData entity) => new List<SqlParameter>
            {
                new SqlParameter("@order_key", entity.OrderKey),
                new SqlParameter("@account_key", entity.AccountKey),
                new SqlParameter("@account_contact_key", entity.AccountContactKey),
                new SqlParameter("@order_num", entity.OrderNum),
                new SqlParameter("@order_entry_date", entity.OrderEntryDate),
                new SqlParameter("@order_status_key", entity.OrderStatusKey),
                new SqlParameter("@order_status_date", entity.OrderStatusDate),
                new SqlParameter("@order_ship_date", entity.OrderShipDate),
                new SqlParameter("@account_rep_key", entity.AccountRepKey),
                new SqlParameter("@order_complete_date", entity.OrderCompleteDate),
                new SqlParameter("@order_value_sum", entity.OrderValueSum),
                new SqlParameter("@order_item_count", entity.OrderItemCount),
                new SqlParameter("@deliver_by_date", entity.DeliverByDate),
                new SqlParameter("@sales_rep_key", entity.SalesRepKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderHeaderData entity) => MapParamsForDelete(entity.OrderKey);

        public List<SqlParameter> MapParamsForDelete(int order_key) => new List<SqlParameter>
            {
                new SqlParameter("@order_key", order_key),
                GetOutParam()
            };
    }
}
