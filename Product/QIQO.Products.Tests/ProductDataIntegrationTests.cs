using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Products.Data;
using System;
using Xunit;

namespace QIQO.Products.Tests
{
    public class ProductDataFixture : IDisposable
    {
        public IProductDbContext DbContext { get; private set; }
        public ProductDataFixture()
        {
            DbContext = new ProductDbContext(@"Data Source=RDRRL8\D1;User ID=businessuser;Password=businessuser512;Database=ProductManagement;Application Name=QIQOBusinessProductsIntegrationTester");
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
    public class ProductDataIntegrationTests : IClassFixture<ProductDataFixture>
    {
        ProductDataFixture _fixture;

        public ProductDataIntegrationTests(ProductDataFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void ProductDataAccessIntegrationTest()
        {
            var _productMapper = new ProductMap();
            var _productDataLog = new Mock<ILogger<ProductData>>();
            var sut = new ProductRepository(_fixture.DbContext, _productMapper, _productDataLog.Object);
            var product = new ProductData
            {
                ProductCode = "TEST10",
                //ProductKey = 24,
                ProductDesc = "TEST10",
                ProductTypeKey = 3, //SWEET6
                ProductName = "TEST10",
                ProductNameShort = "TEST10",
                ProductNameLong = "TEST10",
                ProductImagePath = "TEST"
            };
            sut.Insert(product);
            product = sut.GetByCode("TEST10", "TEST");
            sut.Save(product);
            sut.Delete(product);
            //sut.Insert(account);
        }
        [Fact]
        public void ProductTypeDataAccessIntegrationTest()
        {
            var _productMapper = new ProductTypeMap();
            var _productDataLog = new Mock<ILogger<ProductTypeData>>();
            var sut = new ProductTypeRepository(_fixture.DbContext, _productMapper, _productDataLog.Object);
            var product = new ProductTypeData
            {
                ProductTypeCode = "TEST10",
                ProductTypeDesc = "TEST10",
                //ProductTypeKey = 3, //SWEET6
                ProductTypeName = "TEST10",
                ProductTypeCategory = "TEST10",
            };
            sut.Insert(product);
            product = sut.GetByCode("TEST10", "TEST");
            sut.Save(product);
            sut.Delete(product);
            //sut.Insert(account);
        }
    }
}
