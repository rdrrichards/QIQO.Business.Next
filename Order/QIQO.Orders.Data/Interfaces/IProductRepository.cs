using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Data
{
    public interface IProductRepository : IRepository<ProductData> { }
    public interface IProductTypeRepository : IRepository<ProductTypeData> { }
}
