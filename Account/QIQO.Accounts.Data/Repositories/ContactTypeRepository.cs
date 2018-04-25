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
        private IAccountDbContext entityContext;
        public ContactTypeRepository(IAccountDbContext dbc, IContactTypeMap map, ILogger<ContactTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<ContactTypeData> GetAll()
        {
            Log.LogInformation("Accessing ContactTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_type_all"));
        }

        public override ContactTypeData GetByID(int contact_type_key)
        {
            Log.LogInformation("Accessing ContactTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_type_key", contact_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_type_get", pcol));
        }

        public override ContactTypeData GetByCode(string contact_type_code, string entityCode)
        {
            Log.LogInformation("Accessing ContactTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@contact_type_code", contact_type_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_type_get_c", pcol));
        }

        public override void Insert(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactTypeData entity)
        {
            Log.LogInformation("Accessing ContactTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_contact_type_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing ContactTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_type_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_contact_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing ContactTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_contact_type_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ContactTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_contact_type_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
