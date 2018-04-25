using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AuditLogRepository : RepositoryBase<AuditLogData>,
                                     IAuditLogRepository
    {
        private ICompanyDbContext entityContext;
        public AuditLogRepository(ICompanyDbContext dbc, IAuditLogMap map, ILogger<AuditLogData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AuditLogData> GetAll()
        {
            Log.LogInformation("Accessing AuditLogRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_audit_log_all"));
        }

        public override AuditLogData GetByID(int audit_log_key)
        {
            Log.LogInformation("Accessing AuditLogRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@audit_log_key", audit_log_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_audit_log_get", pcol));
        }

        public override AuditLogData GetByCode(string audit_log_code, string entityCode)
        {
            Log.LogInformation("Accessing AuditLogRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@audit_log_code", audit_log_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_audit_log_get_c", pcol));
        }

        public override void Insert(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AuditLogData entity)
        {
            Log.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_audit_log_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AuditLogRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@audit_log_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_audit_log_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_audit_log_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AuditLogData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_audit_log_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
