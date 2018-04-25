using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class ProductMap : MapperBase, IProductMap
    { 
        public ProductData Map(IDataReader record)
        {
            try
            {
                return new ProductData()
                {
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    ProductCode = NullCheck<string>(record["product_code"]),
                    ProductName = NullCheck<string>(record["product_name"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    ProductNameShort = NullCheck<string>(record["product_name_short"]),
                    ProductNameLong = NullCheck<string>(record["product_name_long"]),
                    ProductImagePath = NullCheck<string>(record["product_image_path"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ProductMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ProductData entity) => new List<SqlParameter>
            {
                new SqlParameter("@product_key", entity.ProductKey),
                new SqlParameter("@product_type_key", entity.ProductTypeKey),
                new SqlParameter("@product_code", entity.ProductCode),
                new SqlParameter("@product_name", entity.ProductName),
                new SqlParameter("@product_desc", entity.ProductDesc),
                new SqlParameter("@product_name_short", entity.ProductNameShort),
                new SqlParameter("@product_name_long", entity.ProductNameLong),
                new SqlParameter("@product_image_path", entity.ProductImagePath),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ProductData entity) => MapParamsForDelete(entity.ProductKey);

        public List<SqlParameter> MapParamsForDelete(int product_key) => new List<SqlParameter>
            {
                new SqlParameter("@product_key", product_key),
                GetOutParam()
            };
    }
}
