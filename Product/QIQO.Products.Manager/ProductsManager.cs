using Microsoft.Extensions.Logging;
using QIQO.MQ;
using QIQO.Products.Data;
using QIQO.Products.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;

namespace QIQO.Products.Manager
{
    public interface IProductsManager {
        Task SaveProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string productCode);
        Task DeleteProductAsync(int productKey);
    }
    public class ProductsManager : IProductsManager
    {
        private readonly ILogger<ProductsManager> _log;
        private readonly IMQPublisher _mqPublisher;
        private readonly IProductRepository _productRepository;
        private readonly IProductEntityService _productEntityService;

        public ProductsManager(ILogger<ProductsManager> logger, IMQPublisher mqPublisher,
            IProductRepository productRepository, IProductEntityService productEntityService)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _productRepository = productRepository;
            _productEntityService = productEntityService;
        }
        public Task DeleteProductAsync(int productKey)
        {
            return Task.Factory.StartNew(() => _productRepository.DeleteByID(productKey));
        }

        public Task<Product> GetProductAsync(string productCode)
        {
            return Task.Factory.StartNew(() => {
                return _productEntityService.Map(_productRepository.GetByCode(productCode, string.Empty));
            });
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.Factory.StartNew(() => {
                return _productEntityService.Map(_productRepository.GetAll());
            });
        }

        public Task SaveProductAsync(Product product)
        {
            return Task.Factory.StartNew(() => {
                _productRepository.Save(_productEntityService.Map(product));
                _mqPublisher.Send(product, "product", "product.add", "product.add");
            });
        }
    }
}
