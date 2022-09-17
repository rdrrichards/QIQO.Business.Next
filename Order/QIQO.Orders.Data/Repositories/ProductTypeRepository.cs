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

        public ProductTypeRepository(IOrderDbContext dbc, IProductTypeMap map, ILogger<ProductTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }
        public override IEnumerable<ProductTypeData> GetAll()
        {
            Log.LogInformation("Accessing ProductTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeAll"));
        }

        public IEnumerable<ProductTypeData> GetAllByCategory(string category)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeCategory", category) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGetByCategory", pcol));
        }

        public override ProductTypeData GetByID(int product_type_key)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeKey", product_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGet", pcol));
        }

        public override ProductTypeData GetByCode(string product_type_code, string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@ProductTypeCode", product_type_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspProductTypeGetByCompany", pcol));
        }

        public override void Insert(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductTypeData entity)
        {
            Log.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductTypeCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDeleteByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ProductTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspProductTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
