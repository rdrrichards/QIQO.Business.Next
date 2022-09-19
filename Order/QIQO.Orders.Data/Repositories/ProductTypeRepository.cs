using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class ProductTypeRepository : RepositoryBase<ProductTypeData>, IProductTypeRepository
    {
        private readonly IOrderDbContext entityContext;
        private readonly ILogger<ProductTypeData> _logger;

        public ProductTypeRepository(IOrderDbContext dbc, IProductTypeMap map, ILogger<ProductTypeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }
        public override IEnumerable<ProductTypeData> GetAll()
        {
            _logger.LogInformation("Accessing ProductTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeAll"));
        }

        public IEnumerable<ProductTypeData> GetAllByCategory(string category)
        {
            _logger.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeCategory", category) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGetByCategory", pcol));
        }

        public override ProductTypeData GetByID(int product_type_key)
        {
            _logger.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeKey", product_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGet", pcol));
        }

        public override ProductTypeData GetByCode(string product_type_code, string entity_code)
        {
            _logger.LogInformation("Accessing ProductTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@ProductTypeCode", product_type_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGetByCompany", pcol));
        }

        public override void Insert(ProductTypeData entity)
        {
            _logger.LogInformation("Accessing ProductTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ProductTypeData entity)
        {
            _logger.LogInformation("Accessing ProductTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductTypeData entity)
        {
            _logger.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing ProductTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDeleteByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ProductTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
