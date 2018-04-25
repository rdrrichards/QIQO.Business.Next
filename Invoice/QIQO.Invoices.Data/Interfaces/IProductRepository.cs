using QIQO.Business.Core.Contracts;

namespace QIQO.Invoices.Data
{
    public interface IProductRepository : IRepository<ProductData> { }
    public interface IProductTypeRepository : IRepository<ProductTypeData> { }
}
