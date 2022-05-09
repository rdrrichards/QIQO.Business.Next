using Microsoft.Extensions.Logging;
using QIQO.MQ;
using QIQO.Orders.Data;
using QIQO.Orders.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Manager
{
    public interface IOrdersManager
    {
        Task SaveOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> FindOrdersAsync(int companyKey, string term);
        Task<Order> GetOrderAsync(string orderCode);
        Task DeleteOrderAsync(int orderKey);
        Task<List<Order>> GetOpenOrdersAsync(int companyKey);
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
        public Task DeleteOrderAsync(int orderKey)
        {
            return Task.Run(() => _orderRepository.DeleteByID(orderKey));
        }

        public Task<Order> GetOrderAsync(string orderCode)
        {
            return Task.Run(() => {
                return new Order(_orderRepository.GetByCode(orderCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return Task.Run(() => {
                return _orderEntityService.Map(_orderRepository.GetAll());
            });
        }

        public Task<List<Order>> FindOrdersAsync(int companyKey, string term)
        {
            return Task.Run(() => {
                return _orderEntityService.Map(_orderRepository.FindAll(companyKey, term));
            });
        }

        public Task SaveOrderAsync(Order order)
        {
            return Task.Run(() => {
                _orderRepository.Save(_orderEntityService.Map(order));
                _mqPublisher.Send(order, "order", "order.add", "order.add");
            });
        }

        public Task<List<Order>> GetOpenOrdersAsync(int companyKey)
        {
            return Task.Run(() => {
                return _orderEntityService.Map(_orderRepository.GetAllOpen(companyKey));
            });
        }

    }
}
