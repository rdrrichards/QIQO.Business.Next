using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class PersonRepository : RepositoryBase<PersonData>, IPersonRepository
    {
        private readonly IAccountDbContext entityContext;
        private readonly ILogger<PersonData> _logger;

        public PersonRepository(IAccountDbContext dbc, IPersonMap map, ILogger<PersonData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<PersonData> GetAll()
        {
            _logger.LogInformation("Accessing PersonRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonAll"));
        }

        public IEnumerable<PersonData> GetAll(CompanyData comp)
        {
            _logger.LogInformation("Accessing PersonRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", comp.CompanyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonAllByCompany", pcol));
        }

        public IEnumerable<PersonData> GetAll(AccountData acct)
        {
            _logger.LogInformation("Accessing PersonRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", acct.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonAllByAccount", pcol));
        }

        public override PersonData GetByCode(string account_code, string entityCode)
        {
            _logger.LogInformation("Accessing PersonRepo GetByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonCode", entityCode) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonGetByCode", pcol));
        }

        public override PersonData GetByID(int entityKey)
        {
            _logger.LogInformation("Accessing PersonRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonKey", entityKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonGet", pcol));
        }

        public override void Insert(PersonData entity)
        {
            _logger.LogInformation("Accessing PersonRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(PersonData entity)
        {
            _logger.LogInformation("Accessing PersonRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonData entity)
        {
            _logger.LogInformation("Accessing PersonRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing PersonRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonDeleteByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing PersonRepo DeleteByID function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonDelete", Mapper.MapParamsForDelete(entityKey));
        }

        public PersonData GetByUserName(string user_name)
        {
            _logger.LogInformation("Accessing PersonRepo GetByUserName function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@UserName", user_name) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonGetByCredentials", pcol));
        }

        public IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type)
        {
            _logger.LogInformation("Accessing PersonRepo GetAllReps by Company function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", comp.CompanyKey),
                Mapper.BuildParam("@RepType", rep_type)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonAllByCompanyRepOnly", pcol));
        }

        private void Upsert(PersonData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
