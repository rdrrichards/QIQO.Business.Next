using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class OrderEntityService : IOrderEntityService
    {
        public Order Map(OrderHeaderData ent) => new Order(ent);

        public OrderHeaderData Map(Order ent) => new OrderHeaderData
        {
            OrderKey = ent.OrderKey
        };
    }
}
