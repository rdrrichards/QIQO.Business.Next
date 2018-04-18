using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class CompanyRepository : RepositoryBase<CompanyData>, ICompanyRepository
    {
        private IAccountDbContext entityContext;

        public CompanyRepository(IAccountDbContext dbc, ICompanyMap map, ILogger<CompanyData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CompanyData> GetAll()
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_all"));
        }

        public IEnumerable<CompanyData> GetAll(PersonData person)
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@employee_key", person.PersonKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_all_by_person", pcol));
        }

        public override CompanyData GetByID(int companyKey)
        {
            Log.LogInformation("Accessing CompanyRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", companyKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_get", pcol));
        }

        public override CompanyData GetByCode(string companyCode, string entityCode)
        {
            Log.LogInformation("Accessing CompanyRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_code", companyCode),
                Mapper.BuildParam("@entity_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_get_c", pcol));
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
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CompanyData entity)
        {
            Log.LogInformation("Accessing CompanyRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CompanyData entity)
        {
            Log.LogInformation("Accessing CompanyRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CompanyRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_company_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CompanyRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CompanyData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_company_ups", Mapper.MapParamsForUpsert(entity));
        }
    }

}
