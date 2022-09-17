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
                    OrderItemKey = NullCheck<int>(record["OrderItemKey"]),
                    OrderKey = NullCheck<int>(record["OrderKey"]),
                    OrderItemSeq = NullCheck<int>(record["OrderItemSeq"]),
                    ProductKey = NullCheck<int>(record["ProductKey"]),
                    ProductName = NullCheck<string>(record["ProductName"]),
                    ProductDesc = NullCheck<string>(record["ProductDescription"]),
                    OrderItemQuantity = NullCheck<int>(record["OrderItemQuantity"]),
                    ShiptoAddrKey = NullCheck<int>(record["ShipToAddressKey"]),
                    BilltoAddrKey = NullCheck<int>(record["BillToAddressKey"]),
                    OrderItemShipDate = (DBNull.Value == record["OrderItemShipDate"]) ? null : record["OrderItemShipDate"] as DateTime?,
                    OrderItemCompleteDate = (DBNull.Value == record["OrderItemCompleteDate"]) ? null : record["OrderItemCompleteDate"] as DateTime?,
                    OrderItemPricePer = NullCheck<decimal>(record["OrderItemPricePer"]),
                    OrderItemLineSum = NullCheck<decimal>(record["OrderItemLineSum"]),
                    OrderItemAccountRepKey = NullCheck<int>(record["OrderItemAccountRepKey"]),
                    OrderItemSalesRepKey = NullCheck<int>(record["OrderItemSalesRepKey"]),
                    OrderItemStatusKey = NullCheck<int>(record["OrderItemStatusKey"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"OrderItemMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(OrderItemData entity) => new List<SqlParameter>
            {
                new SqlParameter("@OrderItemKey", entity.OrderItemKey),
                new SqlParameter("@OrderKey", entity.OrderKey),
                new SqlParameter("@OrderItemSeq", entity.OrderItemSeq),
                new SqlParameter("@ProductKey", entity.ProductKey),
                new SqlParameter("@ProductName", entity.ProductName),
                new SqlParameter("@ProductDescription", entity.ProductDesc),
                new SqlParameter("@OrderItemQuantity", entity.OrderItemQuantity),
                new SqlParameter("@ShipToAddressKey", entity.ShiptoAddrKey),
                new SqlParameter("@BillToAddressKey", entity.BilltoAddrKey),
                new SqlParameter("@OrderItemShipDate", entity.OrderItemShipDate),
                new SqlParameter("@OrderItemCompleteDate", entity.OrderItemCompleteDate),
                new SqlParameter("@OrderItemPricePer", entity.OrderItemPricePer),
                new SqlParameter("@OrderItemLineSum", entity.OrderItemLineSum),
                new SqlParameter("@OrderItemAccountRepKey", entity.OrderItemAccountRepKey),
                new SqlParameter("@OrderItemSalesRepKey", entity.OrderItemSalesRepKey),
                new SqlParameter("@OrderItemStatusKey", entity.OrderItemStatusKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(OrderItemData entity) => MapParamsForDelete(entity.OrderItemKey);

        public List<SqlParameter> MapParamsForDelete(int order_item_key) => new List<SqlParameter>
            {
                new SqlParameter("@OrderItemKey", order_item_key),
                GetOutParam()
            };
    }
}
