using QIQO.Orders.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QIQO.Orders.Manager
{
    public interface IOrdersManager
    {
        Task SaveOrderAsync(Order company);
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(string companyCode);
        Task DeleteOrderAsync(int companyKey);
        Task UpdateOrderAsync(Order company);
    }
    public class OrdersManager : IOrdersManager
    {
        public Task DeleteOrderAsync(int companyKey)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(string companyCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveOrderAsync(Order company)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(Order company)
        {
            throw new NotImplementedException();
        }
    }
}
