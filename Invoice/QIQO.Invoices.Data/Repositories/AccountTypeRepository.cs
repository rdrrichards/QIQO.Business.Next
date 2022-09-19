using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class AccountTypeRepository : RepositoryBase<AccountTypeData>,
                                     IAccountTypeRepository
    {
        private readonly IInvoiceDbContext entityContext;
        private readonly ILogger<AccountTypeData> _logger;

        public AccountTypeRepository(IInvoiceDbContext dbc, IAccountTypeMap map, ILogger<AccountTypeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AccountTypeData> GetAll()
        {
            _logger.LogInformation("Accessing AccountTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeAll"));
        }

        public override AccountTypeData GetByID(int account_type_key)
        {
            _logger.LogInformation("Accessing AccountTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountTypeKey", account_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeGet", pcol));
        }

        public override AccountTypeData GetByCode(string account_code, string entityCode)
        {
            _logger.LogInformation("Accessing AccountTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AccountCode", account_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeGetByCompany", pcol));
        }

        public override void Insert(AccountTypeData entity)
        {
            _logger.LogInformation("Accessing AccountTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountTypeData entity)
        {
            _logger.LogInformation("Accessing AccountTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountTypeData entity)
        {
            _logger.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AccountTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AccountTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
