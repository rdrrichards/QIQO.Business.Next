using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class CompanyRepository : RepositoryBase<CompanyData>, ICompanyRepository
    {
        private readonly IAccountDbContext entityContext;

        public CompanyRepository(IAccountDbContext dbc, ICompanyMap map, ILogger<CompanyData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CompanyData> GetAll()
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCompanyAll"));
        }

        public IEnumerable<CompanyData> GetAll(PersonData person)
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@employee_key", person.PersonKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCompanyAllByPerson", pcol));
        }

        public override CompanyData GetByID(int companyKey)
        {
            Log.LogInformation("Accessing CompanyRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", companyKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCompanyGet", pcol));
        }

        public override CompanyData GetByCode(string companyCode, string entityCode)
        {
            Log.LogInformation("Accessing CompanyRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyCode", companyCode),
                Mapper.BuildParam("@entity_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCompanyGetByCode", pcol));
        }

        public string GetNextNumber(CompanyData company, int numberType)
        {
            Log.LogInformation("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entityKey", company.CompanyKey) };
            var spName = "usp_get_next_emp_num";
            switch (numberType)
            {
                case 2:
                    spName = "usp_get_next_emp_num";
                    break;
                case 1:
                    spName = "usp_get_next_acct_num";
                    break;
                case 6:
                    spName = "usp_get_next_vend_num";
                    break;
                default:
                    return "usp_get_next_emp_num";
            }
            using (entityContext) return entityContext.ExecuteSqlStatementAsScalar<string>(spName, pcol);
        }

        public override void Insert(CompanyData entity)
        {
            Log.LogInformation("Accessing CompanyRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CompanyData entity)
        {
            Log.LogInformation("Accessing CompanyRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CompanyData entity)
        {
            Log.LogInformation("Accessing CompanyRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCompanyDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CompanyRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCompanyDeleteByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CompanyRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCompanyDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CompanyData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCompanyUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }

}
