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
        private IInvoiceDbContext entityContext;
        public AccountTypeRepository(IInvoiceDbContext dbc, IAccountTypeMap map, ILogger<AccountTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AccountTypeData> GetAll()
        {
            Log.LogInformation("Accessing AccountTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_type_all"));
        }

        public override AccountTypeData GetByID(int account_type_key)
        {
            Log.LogInformation("Accessing AccountTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_type_key", account_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_type_get", pcol));
        }

        public override AccountTypeData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing AccountTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_type_get_c", pcol));
        }

        public override void Insert(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountTypeData entity)
        {
            Log.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_type_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AccountTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AccountTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_type_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AccountTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_type_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
