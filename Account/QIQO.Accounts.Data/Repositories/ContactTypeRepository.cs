using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class ContactTypeRepository : RepositoryBase<ContactTypeData>,
                                     IContactTypeRepository
    {
        private readonly IAccountDbContext entityContext;
        public ContactTypeRepository(IAccountDbContext dbc, IContactTypeMap map, ILogger<ContactTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<ContactTypeData> GetAll()
        {
            Log.LogInformation("Accessing ContactTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspContactTypeAll"));
        }

        public override ContactTypeData GetByID(int contact_type_key)
        {
            Log.LogInformation("Accessing ContactTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ContactTypeKey", contact_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspContactTypeGet", pcol));
        }

        public override ContactTypeData GetByCode(string contact_type_code, string entityCode)
        {
            Log.LogInformation("Accessing ContactTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@ContactTypeCode", contact_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspContactTypeGetByCompany", pcol));
        }

        public override void Insert(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing ContactTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ContactTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactTypeDeleteByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing ContactTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ContactTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
