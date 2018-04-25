using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class ProductTypeMap : MapperBase, IProductTypeMap
    {
        public ProductTypeData Map(IDataReader record)
        {
            try
            {
                return new ProductTypeData()
                {
                    ProductTypeKey = NullCheck<int>(record["product_type_key"]),
                    ProductTypeCategory = NullCheck<string>(record["product_type_category"]),
                    ProductTypeCode = NullCheck<string>(record["product_type_code"]),
                    ProductTypeName = NullCheck<string>(record["product_type_name"]),
                    ProductTypeDesc = NullCheck<string>(record["product_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("ProductTypeMap Exception occured", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(ProductTypeData entity) => new List<SqlParameter>
            {
                new SqlParameter("@product_type_key", entity.ProductTypeKey),
                new SqlParameter("@product_type_category", entity.ProductTypeCategory),
                new SqlParameter("@product_type_code", entity.ProductTypeCode),
                new SqlParameter("@product_type_name", entity.ProductTypeName),
                new SqlParameter("@product_type_desc", entity.ProductTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ProductTypeData entity) => MapParamsForDelete(entity.ProductTypeKey);

        public List<SqlParameter> MapParamsForDelete(int product_type_key) => new List<SqlParameter>
            {
                new SqlParameter("@product_type_key", product_type_key),
                GetOutParam()
            };
    }
}
