using QIQO.Business.Core.Contracts;
using QIQO.Products.Data;
using QIQO.Products.Domain;

namespace QIQO.Products.Manager
{
    public interface IProductEntityService : IEntityService<Product, ProductData> { }
}
