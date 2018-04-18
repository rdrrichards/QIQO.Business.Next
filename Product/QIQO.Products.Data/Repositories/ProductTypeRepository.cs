using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class ProductTypeRepository : RepositoryBase<ProductTypeData>, IProductTypeRepository
    {
        private IProductDbContext entity_context;

        public ProductTypeRepository(IProductDbContext dbc, IProductTypeMap map, ILogger<ProductTypeData> log) : base(log, map)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ProductTypeData> GetAll()
        {
            Log.LogInformation("Accessing ProductTypeRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_ProductType_all"));
            }
        }


        public override ProductTypeData GetByID(int product_key)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_key", product_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_product_get", pcol));
            }
        }

        public override ProductTypeData GetByCode(string product_code, string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@product_code", product_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_product_get_c", pcol));
            }
        }

        public override void Insert(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(ProductTypeData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}
