using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderItemRepository : RepositoryBase<OrderItemData>, IOrderItemRepository
    {
        private readonly IOrderDbContext entityContext;

        public OrderItemRepository(IOrderDbContext dbc, IOrderItemMap map, ILogger<OrderItemData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<OrderItemData> GetAll()
        {
            Log.LogInformation("Accessing OrderItemRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderItemAll"));
        }

        public IEnumerable<OrderItemData> GetAll(OrderHeaderData order)
        {
            Log.LogInformation("Accessing OrderItemRepo GetAll by InvoiceData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderKey", order.OrderKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderItemAll", pcol));
        }

        public override OrderItemData GetByID(int order_item_key)
        {
            Log.LogInformation("Accessing OrderItemRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderItemKey", order_item_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderItemGet", pcol));
        }

        public override OrderItemData GetByCode(string order_item_code, string entity_code)
        {
            Log.LogInformation("Accessing OrderItemRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@OrderItemCode", order_item_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderItemGet", pcol));
        }

        public override void Insert(OrderItemData entity)
        {
            Log.LogInformation("Accessing OrderItemRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderItemData entity)
        {
            Log.LogInformation("Accessing OrderItemRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderItemData entity)
        {
            Log.LogInformation("Accessing OrderItemRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderItemDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing OrderItemRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_item_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderItemDel", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing OrderItemRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderItemDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(OrderItemData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderItemUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
