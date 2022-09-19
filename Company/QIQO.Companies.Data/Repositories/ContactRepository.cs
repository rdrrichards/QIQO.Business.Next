using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class ContactRepository : RepositoryBase<ContactData>, IContactRepository
    {
        private readonly ICompanyDbContext entityContext;
        private readonly ILogger<ContactData> _logger;

        public ContactRepository(ICompanyDbContext dbc, IContactMap map, ILogger<ContactData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<ContactData> GetAll()
        {
            _logger.LogInformation("Accessing ContactRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspContactAll"));
        }

        public IEnumerable<ContactData> GetAll(int entityKey, int entityTypeKey)
        {
            _logger.LogInformation("Accessing ContactRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_contact_all_by_entity", pcol));
        }

        public override ContactData GetByID(int contact_key)
        {
            _logger.LogInformation("Accessing ContactRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ContactKey", contact_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspContactGet", pcol));
        }

        public override ContactData GetByCode(string contact_code, string entityCode)
        {
            _logger.LogInformation("Accessing ContactRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@contact_code", contact_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspContactGetByCode", pcol));
        }

        public override void Insert(ContactData entity)
        {
            _logger.LogInformation("Accessing ContactRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(ContactData entity)
        {
            _logger.LogInformation("Accessing ContactRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(ContactData entity)
        {
            _logger.LogInformation("Accessing ContactRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing ContactRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@contact_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactDeleteByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing ContactRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(ContactData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspContactUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
