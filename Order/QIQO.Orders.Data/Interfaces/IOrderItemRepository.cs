using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Orders.Data
{
    public interface IOrderItemRepository : IRepository<OrderItemData>
    {
        IEnumerable<OrderItemData> GetAll(OrderHeaderData order);
    }
}
