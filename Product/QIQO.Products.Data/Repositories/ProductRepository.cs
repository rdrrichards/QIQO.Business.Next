﻿using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class ProductRepository : RepositoryBase<ProductData>, IProductRepository
    {
        private IProductDbContext entity_context;

        public ProductRepository(IProductDbContext dbc, IProductMap map, ILogger<ProductData> log) : base(log, map)
        {
            entity_context = dbc;
        }

        public override IEnumerable<ProductData> GetAll()
        {
            Log.LogInformation("Accessing ProductRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_product_all"));
            }
        }


        public override ProductData GetByID(int product_key)
        {
            Log.LogInformation("Accessing ProductRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_key", product_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_product_get", pcol));
            }
        }

        public override ProductData GetByCode(string product_code, string entity_code)
        {
            Log.LogInformation("Accessing ProductRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@product_code", product_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_product_get_c", pcol));
            }
        }

        public override void Insert(ProductData entity)
        {
            Log.LogInformation("Accessing ProductRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ProductData entity)
        {
            Log.LogInformation("Accessing ProductRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ProductData entity)
        {
            Log.LogInformation("Accessing ProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing ProductRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing ProductRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(ProductData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_product_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}