using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AddressRepository : RepositoryBase<AddressData>, IAddressRepository
    {
        private readonly ICompanyDbContext entityContext;

        public AddressRepository(ICompanyDbContext dbc, IAddressMap map, ILogger<AddressData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AddressData> GetAll()
        {
            Log.LogInformation("Accessing AddressRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_all"));
        }

        public IEnumerable<AddressData> GetAll(int entity_key, int entity_type)
        {
            Log.LogInformation("Accessing AddressRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_all_by_entity", pcol));
        }

        public override AddressData GetByID(int address_key)
        {
            Log.LogInformation("Accessing AddressRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_key", address_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_get", pcol));
        }

        public override AddressData GetByCode(string address_code, string entity_code)
        {
            Log.LogInformation("Accessing AddressRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@address_code", address_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_get_c", pcol));
        }

        public override void Insert(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing AddressRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_del_c", pcol);
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_del", Mapper.MapParamsForDelete(entity_key));
        }

        private void Upsert(AddressData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
