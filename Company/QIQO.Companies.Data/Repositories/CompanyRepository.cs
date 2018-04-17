using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class CompanyRepository : RepositoryBase<CompanyData>, ICompanyRepository
    {
        private ICompanyDbContext entityContext;

        public CompanyRepository(ICompanyDbContext dbc, ICompanyMap map, ILogger<CompanyData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CompanyData> GetAll()
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_all"));
            }
        }

        public IEnumerable<CompanyData> GetAll(PersonData person)
        {
            Log.LogInformation("Accessing CompanyRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@employee_key", person.PersonKey) };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_all_by_person", pcol));
            }
        }

        public override CompanyData GetByID(int company_key)
        {
            Log.LogInformation("Accessing CompanyRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company_key) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_get", pcol));
            }
        }

        public override CompanyData GetByCode(string company_code, string entity_code)
        {
            Log.LogInformation("Accessing CompanyRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_code", company_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_company_get_c", pcol));
            }
        }

        public string GetNextNumber(CompanyData company, int number_type)
        {
            Log.LogInformation("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_key", company.CompanyKey) };
            switch (number_type)
            {
                case 3:
                    return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_emp_num", pcol);
                case 4:
                    return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_acct_num", pcol);
                case 5:
                    return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_vend_num", pcol);
                default:
                    return "";
            }
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
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing CompanyRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_company_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing CompanyRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_company_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(CompanyData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_company_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }

}
