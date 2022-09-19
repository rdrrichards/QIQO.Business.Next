using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class EntityEntityRepository : RepositoryBase<EntityEntityData>,
                                     IEntityEntityRepository
    {
        private readonly IAccountDbContext entityContext;
        private readonly ILogger<EntityEntityData> _logger;

        public EntityEntityRepository(IAccountDbContext dbc, IEntityEntityMap map, ILogger<EntityEntityData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<EntityEntityData> GetAll()
        {
            _logger.LogInformation("Accessing EntityEntityRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspEntityEntityAll"));
        }

        public override EntityEntityData GetByID(int entity_entity_key)
        {
            _logger.LogInformation("Accessing EntityEntityRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@EntityEntityKey", entity_entity_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspEntityEntityGet", pcol));
        }

        public override EntityEntityData GetByCode(string entity_entity_code, string entityCode)
        {
            _logger.LogInformation("Accessing EntityEntityRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@entity_entity_code", entity_entity_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_entity_entity_get_c", pcol));
        }

        public override void Insert(EntityEntityData entity)
        {
            _logger.LogInformation("Accessing EntityEntityRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(EntityEntityData entity)
        {
            _logger.LogInformation("Accessing EntityEntityRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(EntityEntityData entity)
        {
            _logger.LogInformation("Accessing EntityEntityRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspEntityEntityDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing EntityEntityRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_entity_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_entity_entity_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing EntityEntityRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspEntityEntityDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(EntityEntityData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspEntityEntityUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
