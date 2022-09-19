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
        private readonly ICompanyDbContext entityContext;
        private readonly ILogger<AuditLogData> _logger;

        public AuditLogRepository(ICompanyDbContext dbc, IAuditLogMap map, ILogger<AuditLogData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AuditLogData> GetAll()
        {
            _logger.LogInformation("Accessing AuditLogRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogAll"));
        }

        public override AuditLogData GetByID(int LogKey)
        {
            _logger.LogInformation("Accessing AuditLogRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@LogKey", LogKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogGet", pcol));
        }

        public override AuditLogData GetByCode(string audit_log_code, string entityCode)
        {
            _logger.LogInformation("Accessing AuditLogRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@audit_log_code", audit_log_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAuditLogGetByCompany", pcol));
        }

        public override void Insert(AuditLogData entity)
        {
            _logger.LogInformation("Accessing AuditLogRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AuditLogData entity)
        {
            _logger.LogInformation("Accessing AuditLogRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AuditLogData entity)
        {
            _logger.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AuditLogRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@audit_log_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AuditLogRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AuditLogData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAuditLogUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
