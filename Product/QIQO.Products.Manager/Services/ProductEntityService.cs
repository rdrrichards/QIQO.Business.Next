using QIQO.Products.Data;
using QIQO.Products.Domain;

namespace QIQO.Products.Manager
{
    public class ProductEntityService : IProductEntityService
    {
        public Product Map(ProductData ent) => new Product(ent);

        public ProductData Map(Product ent)
        {
            return new ProductData {
                ProductKey = ent.ProductKey,
                ProductCode = ent.ProductCode,
                ProductName = ent.ProductName,
                ProductDesc = ent.ProductDesc,
                ProductTypeKey = (int)ent.ProductType,
                ProductNameLong = ent.ProductNameLong,
                ProductNameShort = ent.ProductNameShort,
                ProductImagePath = ent.ProductImagePath,
                AuditAddDatetime = ent.AddedDateTime,
                AuditAddUserId = ent.AddedUserID,
                AuditUpdateDatetime = ent.UpdateDateTime,
                AuditUpdateUserId = ent.UpdateUserID
            };
        }
    }
}
