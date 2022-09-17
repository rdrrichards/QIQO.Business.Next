using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AttributeTypeRepository : RepositoryBase<AttributeTypeData>,
                                     IAttributeTypeRepository
    {
        private readonly ICompanyDbContext entityContext;
        public AttributeTypeRepository(ICompanyDbContext dbc, IAttributeTypeMap map, ILogger<AttributeTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AttributeTypeData> GetAll()
        {
            Log.LogInformation("Accessing AttributeTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeTypeAll"));
        }

        public override AttributeTypeData GetByID(int attribute_type_key)
        {
            Log.LogInformation("Accessing AttributeTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AttributeTypeKey", attribute_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeTypeGet", pcol));
        }

        public override AttributeTypeData GetByCode(string attribute_type_code, string entityCode)
        {
            Log.LogInformation("Accessing AttributeTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AttributeTypeCode", attribute_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAttributeTypeGetByCompany", pcol));
        }

        public override void Insert(AttributeTypeData entity)
        {
            Log.LogInformation("Accessing AttributeTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AttributeTypeData entity)
        {
            Log.LogInformation("Accessing AttributeTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AttributeTypeData entity)
        {
            Log.LogInformation("Accessing AttributeTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeTypeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AttributeTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AttributeTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeTypeDelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AttributeTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeTypeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AttributeTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAttributeTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
