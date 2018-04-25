using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class PersonTypeRepository : RepositoryBase<PersonTypeData>,
                                     IPersonTypeRepository
    {
        private ICompanyDbContext entityContext;
        public PersonTypeRepository(ICompanyDbContext dbc, IPersonTypeMap map, ILogger<PersonTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<PersonTypeData> GetAll()
        {
            Log.LogInformation("Accessing PersonTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_type_all"));
        }

        public override PersonTypeData GetByID(int person_type_key)
        {
            Log.LogInformation("Accessing PersonTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_type_key", person_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_type_get", pcol));
        }

        public override PersonTypeData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing PersonTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get_c", pcol));
        }

        public override void Insert(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonTypeData entity)
        {
            Log.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing PersonTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(PersonTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
