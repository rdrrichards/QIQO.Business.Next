using QIQO.Business.Core.Contracts;

namespace QIQO.Products.Data
{
    public interface IProductRepository : IRepository<ProductData> { }
    public interface IProductTypeRepository : IRepository<ProductTypeData> { }


    public interface IProductMap : IMapper<ProductData> { }
    public interface IProductTypeMap : IMapper<ProductTypeData> { }
}
