﻿using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceItemRepository : RepositoryBase<InvoiceItemData>, IInvoiceItemRepository
    {
        private readonly IInvoiceDbContext entityContext;

        public InvoiceItemRepository(IInvoiceDbContext dbc, IInvoiceItemMap map, ILogger<InvoiceItemData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<InvoiceItemData> GetAll()
        {
            Log.LogInformation("Accessing InvoiceItemRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_item_all"));
        }

        public IEnumerable<InvoiceItemData> GetAll(InvoiceData invoice)
        {
            Log.LogInformation("Accessing InvoiceItemRepo GetAll by InvoiceData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_key", invoice.InvoiceKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_item_all", pcol));
        }

        public override InvoiceItemData GetByID(int invoice_item_key)
        {
            Log.LogInformation("Accessing InvoiceItemRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_item_key", invoice_item_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_item_get", pcol));
        }

        public InvoiceItemData GetByOrderItemID(int order_item_key)
        {
            Log.LogInformation("Accessing InvoiceItemRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_item_key", order_item_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_item_get_by_order_item", pcol));
        }

        public override InvoiceItemData GetByCode(string invoice_item_code, string entity_code)
        {
            Log.LogInformation("Accessing InvoiceItemRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@invoice_item_code", invoice_item_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_item_get_c", pcol));
        }

        public override void Insert(InvoiceItemData entity)
        {
            Log.LogInformation("Accessing InvoiceItemRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(InvoiceItemData entity)
        {
            Log.LogInformation("Accessing InvoiceItemRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceItemData entity)
        {
            Log.LogInformation("Accessing InvoiceItemRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_item_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing InvoiceItemRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_item_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_item_del_c", pcol);
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing InvoiceItemRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_item_del", Mapper.MapParamsForDelete(entity_key));
        }

        private void Upsert(InvoiceItemData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_item_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
