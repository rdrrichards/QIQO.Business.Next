using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class EntityEntityRepository : RepositoryBase<EntityEntityData>,
                                     IEntityEntityRepository
    {
        private ICompanyDbContext entityContext;
        public EntityEntityRepository(ICompanyDbContext dbc, IEntityEntityMap map, ILogger<EntityEntityData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<EntityEntityData> GetAll()
        {
            Log.LogInformation("Accessing EntityEntityRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_entity_entity_all"));
        }

        public override EntityEntityData GetByID(int entity_entity_key)
        {
            Log.LogInformation("Accessing EntityEntityRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_entity_key", entity_entity_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_entity_entity_get", pcol));
        }

        public override EntityEntityData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing EntityEntityRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get_c", pcol));
        }

        public override void Insert(EntityEntityData entity)
        {
            Log.LogInformation("Accessing EntityEntityRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(EntityEntityData entity)
        {
            Log.LogInformation("Accessing EntityEntityRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(EntityEntityData entity)
        {
            Log.LogInformation("Accessing EntityEntityRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing EntityEntityRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing EntityEntityRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(EntityEntityData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
