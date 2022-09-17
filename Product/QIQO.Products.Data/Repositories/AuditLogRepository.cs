using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class AuditLogRepository : RepositoryBase<AuditLogData>,
                                     IAuditLogRepository
    {
        private readonly IProductDbContext entityContext;
        public AuditLogRepository(IProductDbContext dbc, IAuditLogMap map, ILogger<AuditLogData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AuditLogData> GetAll()
        {
            Log.LogInformation("Accessing AuditLogRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogAll"));
        }

        public override AuditLogData GetByID(int LogKey)
        {
            Log.LogInformation("Accessing AuditLogRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@LogKey", LogKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogGet", pcol));
        }

        public override AuditLogData GetByCode(string audit_log_code, string entityCode)
        {
            Log.LogInformation("Accessing AuditLogRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AuditLogCode", audit_log_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogGetByCode", pcol));
        }

        public override void Insert(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AuditLogRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AuditLogCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AuditLogData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
