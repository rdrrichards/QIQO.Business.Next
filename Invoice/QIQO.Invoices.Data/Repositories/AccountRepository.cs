using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class AccountRepository : RepositoryBase<AccountData>,
                                     IAccountRepository
    {
        private readonly IInvoiceDbContext entityContext;
        private readonly ILogger<AccountData> _logger;

        public AccountRepository(IInvoiceDbContext dbc, IAccountMap map, ILogger<AccountData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AccountData> GetAll()
        {
            _logger.LogInformation("Accessing AccountRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountAll"));
        }

        //public IEnumerable<AccountData> GetAll(CompanyData company)
        //{
        //    _logger.LogInformation("Accessing AccountRepo GetAll function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", company.CompanyKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountAllByCompany", pcol));
        //}

        public IEnumerable<AccountData> GetAll(PersonData employee)
        {
            _logger.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonKey", employee.PersonKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountAllByPerson", pcol));
        }

        public IEnumerable<AccountData> FindAll(int company_key, string pattern)
        {
            _logger.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@account_pattern", pattern)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountSearch", pcol));
        }

        public override AccountData GetByID(int account_key)
        {
            _logger.LogInformation("Accessing AccountRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountGet", pcol));
        }

        public override AccountData GetByCode(string account_code, string entityCode)
        {
            _logger.LogInformation("Accessing AccountRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AccountCode", account_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountGetByCompany", pcol));
        }

        public override void Insert(AccountData entity)
        {
            _logger.LogInformation("Accessing AccountRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountData entity)
        {
            _logger.LogInformation("Accessing AccountRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountData entity)
        {
            _logger.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AccountRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AccountData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountUpsert", Mapper.MapParamsForUpsert(entity));
        }

        public string GetNextNumber(AccountData account, int entityDesc)
        {
            _logger.LogInformation("Accessing AccountRepo GetNextNumber function");
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
