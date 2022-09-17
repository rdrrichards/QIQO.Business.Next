using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class ProductMap : MapperBase, IProductMap
    {
        public ProductData Map(IDataReader record)
        {
            try
            {
                return new ProductData()
                {
                    ProductKey = NullCheck<int>(record["ProductKey"]),
                    ProductTypeKey = NullCheck<int>(record["ProductTypeKey"]),
                    ProductCode = NullCheck<string>(record["ProductCode"]),
                    ProductName = NullCheck<string>(record["ProductName"]),
                    ProductDesc = NullCheck<string>(record["ProductDescription"]),
                    ProductNameShort = NullCheck<string>(record["ProductNameShort"]),
                    ProductNameLong = NullCheck<string>(record["ProductNameLong"]),
                    ProductImagePath = NullCheck<string>(record["ProductImagePath"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"ProductMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(ProductData entity) => new List<SqlParameter>
            {
                new SqlParameter("@ProductKey", entity.ProductKey),
                new SqlParameter("@ProductTypeKey", entity.ProductTypeKey),
                new SqlParameter("@ProductCode", entity.ProductCode),
                new SqlParameter("@ProductName", entity.ProductName),
                new SqlParameter("@ProductDescription", entity.ProductDesc),
                new SqlParameter("@ProductNameShort", entity.ProductNameShort),
                new SqlParameter("@ProductNameLong", entity.ProductNameLong),
                new SqlParameter("@ProductImagePath", entity.ProductImagePath),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(ProductData entity) => MapParamsForDelete(entity.ProductKey);

        public List<SqlParameter> MapParamsForDelete(int product_key) => new List<SqlParameter>
            {
                new SqlParameter("@ProductKey", product_key),
                GetOutParam()
            };
    }
}
