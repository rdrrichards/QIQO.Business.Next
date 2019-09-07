using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class OrderEntityService : IOrderEntityService
    {
        public Order Map(OrderHeaderData ent) => new Order(ent);

        public OrderHeaderData Map(Order ent) => new OrderHeaderData
        {
            OrderKey = ent.OrderKey,
            OrderEntryDate = ent.OrderEntryDate,
            AccountKey = ent.AccountKey,
            AccountContactKey = ent.AccountContactKey,
            OrderNum = ent.OrderNumber,
            OrderCompleteDate = ent.OrderCompleteDate,
            OrderItemCount = ent.OrderItemCount,
            OrderValueSum = ent.OrderValueSum,
            OrderStatusDate = ent.OrderStatusDate,
            OrderShipDate = ent.OrderShipDate,
            OrderStatusKey = (int)ent.OrderStatus,
            DeliverByDate = ent.DeliverByDate,
            AccountRepKey = ent.AccountRepKey,
            SalesRepKey = ent.SalesRepKey,
            AuditAddUserId = ent.AddedUserID,
            AuditAddDatetime = ent.AddedDateTime,
            AuditUpdateUserId = ent.UpdateUserID,
            AuditUpdateDatetime = ent.UpdateDateTime
        };
    }
}
