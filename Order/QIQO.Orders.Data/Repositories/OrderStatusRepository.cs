using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderStatusRepository : RepositoryBase<OrderStatusData>, IOrderStatusRepository //, IStatusRepository<OrderStatusData>
    {
        private readonly IOrderDbContext entityContext;

        public OrderStatusRepository(IOrderDbContext dbc, IOrderStatusMap map, ILogger<OrderStatusData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<OrderStatusData> GetAll()
        {
            Log.LogInformation("Accessing OrderStatusRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_order_status_all"));
        }

        public override OrderStatusData GetByID(int order_status_key)
        {
            Log.LogInformation("Accessing OrderStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_status_key", order_status_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_order_status_get", pcol));
        }

        public override OrderStatusData GetByCode(string order_status_code, string entity_code)
        {
            Log.LogInformation("Accessing OrderStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_status_code", order_status_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_order_status_get_c", pcol));
        }

        public override void Insert(OrderStatusData entity)
        {
            Log.LogInformation("Accessing OrderStatusRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderStatusData entity)
        {
            Log.LogInformation("Accessing OrderStatusRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderStatusData entity)
        {
            Log.LogInformation("Accessing OrderStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_order_status_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing OrderStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_status_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_order_status_del_c", pcol);
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing OrderStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_order_status_del", Mapper.MapParamsForDelete(entity_key));
        }

        private void Upsert(OrderStatusData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_order_status_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
