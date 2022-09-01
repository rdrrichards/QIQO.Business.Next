using Dapr.Client;
using Microsoft.Extensions.Logging;
using Moq;
using QIQO.MQ;
using QIQO.Orders.Data;
using QIQO.Orders.Domain;
using QIQO.Orders.Manager;
using Xunit;

namespace QIQO.Orders.Tests
{
    public class OrderManagerUnitTests
    {
        private readonly Mock<ILogger<OrdersManager>> _mockLog;
        private readonly Mock<DaprClient> _mqPublisher;
        private readonly Mock<IOrderHeaderRepository> _orderRepository;
        private readonly Mock<IOrderEntityService> _orderEntityService;

        public OrderManagerUnitTests()
        {
            _mockLog = new Mock<ILogger<OrdersManager>>();
            _mqPublisher = new Mock<DaprClient>();
            _orderRepository = new Mock<IOrderHeaderRepository>();
            _orderEntityService = new Mock<IOrderEntityService>();

            _orderRepository.Setup(m => m.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(new OrderHeaderData());

            _orderEntityService.Setup(m => m.Map(It.IsAny<OrderHeaderData>())).Returns(new Order(new OrderHeaderData()));
            _orderEntityService.Setup(m => m.Map(It.IsAny<Order>())).Returns(new OrderHeaderData());
        }
        [Fact]
        public async void OrdersManager_GetOrdersAsync_IsEmpty()
        {
            var sut = new OrdersManager(_mockLog.Object, _mqPublisher.Object, _orderRepository.Object, _orderEntityService.Object);

            var retVal = await sut.GetOrdersAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public async void OrdersManager_GetOrderAsync_NotNull()
        {
            var sut = new OrdersManager(_mockLog.Object, _mqPublisher.Object, _orderRepository.Object, _orderEntityService.Object);

            var retVal = await sut.GetOrderAsync("TEST");

            Assert.NotNull(retVal);
        }
        [Fact]
        public async void OrdersManager_DeleteOrderAsync_DoesntFail()
        {
            var sut = new OrdersManager(_mockLog.Object, _mqPublisher.Object, _orderRepository.Object, _orderEntityService.Object);

            await sut.DeleteOrderAsync(0);

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void OrdersManager_SaveOrderAsync_DoesntFail()
        {
            var sut = new OrdersManager(_mockLog.Object, _mqPublisher.Object, _orderRepository.Object, _orderEntityService.Object);

            await sut.SaveOrderAsync(new Order(new OrderHeaderData()));

            // Assert.NotNull(retVal);
        }
    }
}
