using QIQO.Products.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Products.Manager
{
    public interface IProductsManager {
        Task SaveProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string productCode);
        Task DeleteProductAsync(int productKey);
        Task UpdateProductAsync(Product product);
    }
    public class ProductsManager : IProductsManager
    {
        public Task DeleteProductAsync(int productKey)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(string productCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
