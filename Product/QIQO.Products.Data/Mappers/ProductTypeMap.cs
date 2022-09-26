using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class ProductTypeMap : MapperBase, IProductTypeMap
    {
        public ProductTypeData Map(IDataReader record)
        {
            try
            {
                return new ProductTypeData()
                {
                    ProductTypeKey = NullCheck<int>(record["ProductTypeKey"]),
                    ProductTypeCategory = NullCheck<string>(record["ProductTypeCategory"]),
                    ProductTypeCode = NullCheck<string>(record["ProductTypeCode"]),
                    ProductTypeName = NullCheck<string>(record["ProductTypeName"]),
                    ProductTypeDesc = NullCheck<string>(record["ProductTypeDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDatetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDatetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("ProductTypeMap Exception occured", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(ProductTypeData entity) => new List<SqlParameter>
            {
                new SqlParameter("@ProductTypeKey", entity.ProductTypeKey),
                new SqlParameter("@ProductTypeCategory", entity.ProductTypeCategory),
                new SqlParameter("@ProductTypeCode", entity.ProductTypeCode),
                new SqlParameter("@ProductTypeName", entity.ProductTypeName),
                new SqlParameter("@ProductTypeDescription", entity.ProductTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ProductTypeData entity) => MapParamsForDelete(entity.ProductTypeKey);

        public List<SqlParameter> MapParamsForDelete(int product_type_key) => new List<SqlParameter>
            {
                new SqlParameter("@ProductTypeKey", product_type_key),
                GetOutParam()
            };
    }
}
