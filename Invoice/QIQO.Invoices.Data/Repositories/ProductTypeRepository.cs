﻿using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class ProductTypeRepository : RepositoryBase<ProductTypeData>, IProductTypeRepository
    {
        private readonly IInvoiceDbContext entityContext;

        public ProductTypeRepository(IInvoiceDbContext dbc, IProductTypeMap map, ILogger<ProductTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }
        public override IEnumerable<ProductTypeData> GetAll()
        {
            Log.LogInformation("Accessing ProductTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_product_type_all"));
        }

        public IEnumerable<ProductTypeData> GetAllByCategory(string category)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_type_category", category) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_product_type_get_cat", pcol));
        }

        public override ProductTypeData GetByID(int product_type_key)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_type_key", product_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_product_type_get", pcol));
        }

        public override ProductTypeData GetByCode(string product_type_code, string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@product_type_code", product_type_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_product_type_get_c", pcol));
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
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_product_type_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing ProductTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_product_type_del_c", pcol);
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing ProductTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_product_type_del", Mapper.MapParamsForDelete(entity_key));
        }

        private void Upsert(ProductTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_product_type_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
