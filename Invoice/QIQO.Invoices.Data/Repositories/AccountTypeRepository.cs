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
        public AccountTypeRepository(IInvoiceDbContext dbc, IAccountTypeMap map, ILogger<AccountTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AccountTypeData> GetAll()
        {
            Log.LogInformation("Accessing AccountTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeAll"));
        }

        public override AccountTypeData GetByID(int account_type_key)
        {
            Log.LogInformation("Accessing AccountTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountTypeKey", account_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeGet", pcol));
        }

        public override AccountTypeData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing AccountTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AccountCode", account_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAccountTypeGetByCompany", pcol));
        }

        public override void Insert(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AccountTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AccountTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAccountTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
