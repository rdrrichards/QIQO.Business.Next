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
        private readonly ILogger<OrderStatusData> _logger;

        public OrderStatusRepository(IOrderDbContext dbc, IOrderStatusMap map, ILogger<OrderStatusData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<OrderStatusData> GetAll()
        {
            _logger.LogInformation("Accessing OrderStatusRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderStatusAll"));
        }

        public override OrderStatusData GetByID(int order_status_key)
        {
            _logger.LogInformation("Accessing OrderStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderStatusKey", order_status_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderStatusGet", pcol));
        }

        public override OrderStatusData GetByCode(string order_status_code, string entity_code)
        {
            _logger.LogInformation("Accessing OrderStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@OrderStatusCode", order_status_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderStatusGet", pcol));
        }

        public override void Insert(OrderStatusData entity)
        {
            _logger.LogInformation("Accessing OrderStatusRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderStatusData entity)
        {
            _logger.LogInformation("Accessing OrderStatusRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderStatusData entity)
        {
            _logger.LogInformation("Accessing OrderStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderStatusDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing OrderStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderStatusCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderStatusDel", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing OrderStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderStatusDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(OrderStatusData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderStatusUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
