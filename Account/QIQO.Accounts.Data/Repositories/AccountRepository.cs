using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AccountRepository : RepositoryBase<AccountData>,
                                     IAccountRepository
    {
        private readonly IAccountDbContext entityContext;
        public AccountRepository(IAccountDbContext dbc, IAccountMap map, ILogger<AccountData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AccountData> GetAll()
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_all"));
        }

        public IEnumerable<AccountData> GetAll(CompanyData company)
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
                var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_all_by_company", pcol));
        }

        public IEnumerable<AccountData> GetAll(PersonData employee)
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_key", employee.PersonKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_all_by_person", pcol));
        }

        public IEnumerable<AccountData> FindAll(int company_key, string pattern)
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@account_pattern", pattern)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_find", pcol));
        }

        public override AccountData GetByID(int account_key)
        {
            Log.LogInformation("Accessing AccountRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get", pcol));
        }

        public override AccountData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing AccountRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get_c", pcol));
        }

        public override void Insert(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AccountRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AccountData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
        }

        public string GetNextNumber(AccountData account, int entityDesc)
        {
            Log.LogInformation("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entityKey", account.AccountKey) };
            var spName = "usp_get_next_order_num";
            switch (entityDesc)
            {
                case 2:
                    spName = "usp_get_next_order_num";
                    break;
                case 1:
                    spName = "usp_get_next_invoice_num";
                    break;
                case 6:
                    spName = "usp_get_next_contact_num";
                    break;
                default:
                    return "usp_get_next_order_num";
            }
            using (entityContext) return entityContext.ExecuteSqlStatementAsScalar<string>(spName, pcol);
        }
    }
}
