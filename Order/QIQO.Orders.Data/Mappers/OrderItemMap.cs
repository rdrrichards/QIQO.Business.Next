using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderItemMap : MapperBase, IOrderItemMap
    { // OrderItemMap class opener

        public OrderItemData Map(IDataReader record)
        {
            try
            {
                return new OrderItemData()
                {
                    OrderItemKey = NullCheck<int>(record["order_item_key"]),
                    OrderKey = NullCheck<int>(record["order_key"]),
                    OrderItemSeq = NullCheck<int>(record["order_item_seq"]),
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductName = NullCheck<string>(record["product_name"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    OrderItemQuantity = NullCheck<int>(record["order_item_quantity"]),
                    ShiptoAddrKey = NullCheck<int>(record["shipto_addr_key"]),
                    BilltoAddrKey = NullCheck<int>(record["billto_addr_key"]),
                    OrderItemShipDate = (DBNull.Value == record["order_item_ship_date"]) ? null : record["order_item_ship_date"] as DateTime?,
                    OrderItemCompleteDate = (DBNull.Value == record["order_item_complete_date"]) ? null : record["order_item_complete_date"] as DateTime?,
                    OrderItemPricePer = NullCheck<decimal>(record["order_item_price_per"]),
                    OrderItemLineSum = NullCheck<decimal>(record["order_item_line_sum"]),
                    OrderItemAccountRepKey = NullCheck<int>(record["order_item_acct_rep_key"]),
                    OrderItemSalesRepKey = NullCheck<int>(record["order_item_sales_rep_key"]),
                    OrderItemStatusKey = NullCheck<int>(record["order_item_status_key"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderItemMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderItemData entity) => new List<SqlParameter>
            {
                new SqlParameter("@order_item_key", entity.OrderItemKey),
                new SqlParameter("@order_key", entity.OrderKey),
                new SqlParameter("@order_item_seq", entity.OrderItemSeq),
                new SqlParameter("@product_key", entity.ProductKey),
                new SqlParameter("@product_name", entity.ProductName),
                new SqlParameter("@product_desc", entity.ProductDesc),
                new SqlParameter("@order_item_quantity", entity.OrderItemQuantity),
                new SqlParameter("@shipto_addr_key", entity.ShiptoAddrKey),
                new SqlParameter("@billto_addr_key", entity.BilltoAddrKey),
                new SqlParameter("@order_item_ship_date", entity.OrderItemShipDate),
                new SqlParameter("@order_item_complete_date", entity.OrderItemCompleteDate),
                new SqlParameter("@order_item_price_per", entity.OrderItemPricePer),
                new SqlParameter("@order_item_line_sum", entity.OrderItemLineSum),
                new SqlParameter("@order_item_acct_rep_key", entity.OrderItemAccountRepKey),
                new SqlParameter("@order_item_sales_rep_key", entity.OrderItemSalesRepKey),
                new SqlParameter("@order_item_status_key", entity.OrderItemStatusKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderItemData entity) => MapParamsForDelete(entity.OrderItemKey);

        public List<SqlParameter> MapParamsForDelete(int order_item_key) => new List<SqlParameter>
            {
                new SqlParameter("@order_item_key", order_item_key),
                GetOutParam()
            };
    }
}
