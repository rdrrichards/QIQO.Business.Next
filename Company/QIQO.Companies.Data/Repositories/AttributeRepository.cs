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

        public AttributeRepository(ICompanyDbContext dbc, IAttributeMap map, ILogger<AttributeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AttributeData> GetAll()
        {
            Log.LogInformation("Accessing AttributeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeAll"));
        }

        public IEnumerable<AttributeData> GetAll(int entityKey, int entityTypeKey)
        {
            //Log.LogInformation("Accessing AttributeRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeAllByEntity", pcol));
        }

        public override AttributeData GetByID(int attribute_key)
        {
            Log.LogInformation("Accessing AttributeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AttributeKey", attribute_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeGet", pcol));
        }

        public override AttributeData GetByCode(string attributeCode, string entityCode)
        {
            Log.LogInformation("Accessing AttributeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@attribute_code", attributeCode),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeGetByCompany", pcol));
        }

        public override void Insert(AttributeData entity)
        {
            Log.LogInformation("Accessing AttributeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AttributeData entity)
        {
            Log.LogInformation("Accessing AttributeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AttributeData entity)
        {
            Log.LogInformation("Accessing AttributeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AttributeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@attribute_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributedelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AttributeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AttributeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }

}
