using Microsoft.Extensions.Logging;
using Moq;
using QIQO.MQ;
using QIQO.Products.Data;
using QIQO.Products.Domain;
using QIQO.Products.Manager;
using Xunit;

namespace QIQO.Products.Tests
{
    public class ProductManagerUnitTests
    {
        private readonly Mock<ILogger<ProductsManager>> _mockLog;
        private readonly Mock<IMQPublisher> _mqPublisher;
        private readonly Mock<IProductRepository> _companyRepository;
        private readonly Mock<IProductEntityService> _companyEntityService;

        public ProductManagerUnitTests()
        {
            _mockLog = new Mock<ILogger<ProductsManager>>();
            _mqPublisher = new Mock<IMQPublisher>();
            _companyRepository = new Mock<IProductRepository>();
            _companyEntityService = new Mock<IProductEntityService>();

            _companyRepository.Setup(m => m.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(new ProductData { ProductCode = "TEST" });

            _companyEntityService.Setup(m => m.Map(It.IsAny<ProductData>())).Returns(new Product(new ProductData { ProductCode = "TEST" }));
            _companyEntityService.Setup(m => m.Map(It.IsAny<Product>())).Returns(new ProductData { ProductCode = "TEST" });
        }
        [Fact]
        public async void ProductsManager_GetProductsAsync_IsEmpty()
        {
            var sut = new ProductsManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            var retVal = await sut.GetProductsAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public async void ProductsManager_GetProductAsync_NotNull()
        {
            var sut = new ProductsManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            var retVal = await sut.GetProductAsync("TEST");

            Assert.NotNull(retVal);
        }
        [Fact]
        public async void ProductsManager_DeleteProductAsync_DoesntFail()
        {
            var sut = new ProductsManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            await sut.DeleteProductAsync(0);

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void ProductsManager_SaveProductAsync_DoesntFail()
        {
            var sut = new ProductsManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            await sut.SaveProductAsync(new Product(new ProductData { ProductCode = "TEST" }));

            // Assert.NotNull(retVal);
        }
    }
}
