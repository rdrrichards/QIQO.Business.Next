using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class ProductRepository : RepositoryBase<ProductData>, IProductRepository
    {
        private readonly IProductDbContext entityContext;
        private readonly ILogger<ProductData> _logger;

        public ProductRepository(IProductDbContext dbc, IProductMap map, ILogger<ProductData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<ProductData> GetAll()
        {
            _logger.LogInformation("Accessing ProductRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspProductAll"));
        }


        public override ProductData GetByID(int product_key)
        {
            _logger.LogInformation("Accessing ProductRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductKey", product_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductGet", pcol));
        }

        public override ProductData GetByCode(string product_code, string entity_code)
        {
            _logger.LogInformation("Accessing ProductRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@ProductCode", product_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductDeleteByCode", pcol));
        }

        public override void Insert(ProductData entity)
        {
            _logger.LogInformation("Accessing ProductRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ProductData entity)
        {
            _logger.LogInformation("Accessing ProductRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductData entity)
        {
            _logger.LogInformation("Accessing ProductRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing ProductRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing ProductRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ProductData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
