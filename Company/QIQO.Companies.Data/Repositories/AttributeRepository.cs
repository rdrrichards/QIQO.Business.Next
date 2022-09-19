using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AttributeRepository : RepositoryBase<AttributeData>, IAttributeRepository
    {
        private readonly ICompanyDbContext entityContext;
        private readonly ILogger<AttributeData> _logger;

        public AttributeRepository(ICompanyDbContext dbc, IAttributeMap map, ILogger<AttributeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AttributeData> GetAll()
        {
            _logger.LogInformation("Accessing AttributeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeAll"));
        }

        public IEnumerable<AttributeData> GetAll(int entityKey, int entityTypeKey)
        {
            //_logger.LogInformation("Accessing AttributeRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeAllByEntity", pcol));
        }

        public override AttributeData GetByID(int attribute_key)
        {
            _logger.LogInformation("Accessing AttributeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AttributeKey", attribute_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeGet", pcol));
        }

        public override AttributeData GetByCode(string attributeCode, string entityCode)
        {
            _logger.LogInformation("Accessing AttributeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@attribute_code", attributeCode),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeGetByCompany", pcol));
        }

        public override void Insert(AttributeData entity)
        {
            _logger.LogInformation("Accessing AttributeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AttributeData entity)
        {
            _logger.LogInformation("Accessing AttributeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AttributeData entity)
        {
            _logger.LogInformation("Accessing AttributeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AttributeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@attribute_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributedelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AttributeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AttributeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }

}
