using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class OrderItemEntityService : IOrderItemEntityService
    {
        public OrderItem Map(OrderItemData ent) => new OrderItem(ent);

        public OrderItemData Map(OrderItem ent) => new OrderItemData
        {
            OrderKey = ent.OrderKey
        };
    }
}
