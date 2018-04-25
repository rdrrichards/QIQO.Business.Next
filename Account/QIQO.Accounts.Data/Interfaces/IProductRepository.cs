using QIQO.Business.Core.Contracts;

namespace QIQO.Accounts.Data
{
    public interface IProductRepository : IRepository<ProductData> { }
    public interface IProductTypeRepository : IRepository<ProductTypeData> { }
}
