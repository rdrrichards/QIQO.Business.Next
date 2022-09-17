using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class PersonTypeRepository : RepositoryBase<PersonTypeData>,
                                     IPersonTypeRepository
    {
        private readonly IAccountDbContext entityContext;
        public PersonTypeRepository(IAccountDbContext dbc, IPersonTypeMap map, ILogger<PersonTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<PersonTypeData> GetAll()
        {
            Log.LogInformation("Accessing PersonTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonTypeAll"));
        }

        public override PersonTypeData GetByID(int person_type_key)
        {
            Log.LogInformation("Accessing PersonTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonTypeKey", person_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonTypeGet", pcol));
        }

        public override PersonTypeData GetByCode(string person_type_code, string entityCode)
        {
            Log.LogInformation("Accessing PersonTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@PersonTypeCode", person_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_type_get_c", pcol));
        }

        public override void Insert(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing PersonTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_person_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(PersonTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
