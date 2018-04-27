using Microsoft.Extensions.Logging;
using QIQO.MQ;
using QIQO.Orders.Data;
using QIQO.Orders.Domain;
using System;
using System.Collections.Generic;
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
        private readonly IOrderHeaderRepository _orderRepository;
        private readonly IOrderEntityService _orderEntityService;
        private readonly ILogger<OrdersManager> _log;
        private readonly IMQPublisher _mqPublisher;

        public OrdersManager(ILogger<OrdersManager> logger, IMQPublisher mqPublisher,
            IOrderHeaderRepository orderRepository, IOrderEntityService orderEntityService)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _orderRepository = orderRepository;
            _orderEntityService = orderEntityService;
        }
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
