using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class OrderItemEntityService : IOrderItemEntityService
    {
        public OrderItem Map(OrderItemData ent) => new OrderItem(ent);

        public OrderItemData Map(OrderItem ent) => new OrderItemData
        {
            OrderItemKey = ent.OrderItemKey,
            OrderKey = ent.OrderKey,
            OrderItemSeq = ent.OrderItemSeq,
            ProductKey = ent.ProductKey,
            ProductName = ent.ProductName,
            ProductDesc = ent.ProductDesc,
            OrderItemQuantity = ent.OrderItemQuantity,
            OrderItemShipDate = ent.OrderItemShipDate,
            OrderItemCompleteDate = ent.OrderItemCompleteDate,
            OrderItemPricePer = ent.ItemPricePer,
            OrderItemLineSum = ent.OrderItemLineSum,
            AuditAddUserId = ent.AddedUserID,
            AuditAddDatetime = ent.AddedDateTime,
            AuditUpdateUserId = ent.UpdateUserID,
            AuditUpdateDatetime = ent.UpdateDateTime,
            OrderItemStatusKey = (int)ent.OrderItemStatus,
            BilltoAddrKey = 1,
            OrderItemAccountRepKey = 1,
            OrderItemSalesRepKey = 1,
            ShiptoAddrKey = 1
        };
    }
}
