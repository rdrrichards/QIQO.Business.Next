using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AddressPostalRepository : RepositoryBase<AddressPostalData>,
                                     IAddressPostalRepository
    {
        private IAccountDbContext entityContext;
        public AddressPostalRepository(IAccountDbContext dbc, IAddressPostalMap map, ILogger<AddressPostalData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AddressPostalData> GetAll()
        {
            Log.LogInformation("Accessing AddressPostalRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_postal_all"));
        }

        public override AddressPostalData GetByID(int account_postal_key)
        {
            Log.LogInformation("Accessing AddressPostalRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_postal_key", account_postal_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_postal_get", pcol));
        }

        public override AddressPostalData GetByCode(string account_code, string entityCode)
        {
            Log.LogInformation("Accessing AddressPostalRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get_c", pcol));
        }

        public override void Insert(AddressPostalData entity)
        {
            Log.LogInformation("Accessing AddressPostalRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressPostalData entity)
        {
            Log.LogInformation("Accessing AddressPostalRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressPostalData entity)
        {
            Log.LogInformation("Accessing AddressPostalRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AddressPostalRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AddressPostalRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressPostalData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
