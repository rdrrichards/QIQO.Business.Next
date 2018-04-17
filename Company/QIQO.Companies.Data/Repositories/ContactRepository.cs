using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class ContactRepository : RepositoryBase<ContactData>, IContactRepository
    {
        private ICompanyDbContext entityContext;

        public ContactRepository(ICompanyDbContext dbc, IContactMap map, ILogger<ContactData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<ContactData> GetAll()
        {
            Log.LogInformation("Accessing ContactRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_all"));
            }
        }

        public IEnumerable<ContactData> GetAll(int entity_key, int entity_type_key)
        {
            Log.LogInformation("Accessing ContactRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_all_by_entity", pcol));
            }
        }

        public override ContactData GetByID(int contact_key)
        {
            Log.LogInformation("Accessing ContactRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_key", contact_key) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_get", pcol));
            }
        }

        public override ContactData GetByCode(string contact_code, string entity_code)
        {
            Log.LogInformation("Accessing ContactRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@contact_code", contact_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_get_c", pcol));
            }
        }

        public override void Insert(ContactData entity)
        {
            Log.LogInformation("Accessing ContactRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ContactData entity)
        {
            Log.LogInformation("Accessing ContactRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactData entity)
        {
            Log.LogInformation("Accessing ContactRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_contact_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing ContactRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_contact_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing ContactRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_contact_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(ContactData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_contact_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }

}
