using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AddressTypeRepository : RepositoryBase<AddressTypeData>,
                                     IAddressTypeRepository
    {
        private readonly ICompanyDbContext entityContext;
        public AddressTypeRepository(ICompanyDbContext dbc, IAddressTypeMap map, ILogger<AddressTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AddressTypeData> GetAll()
        {
            Log.LogInformation("Accessing AddressTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_type_all"));
        }

        public override AddressTypeData GetByID(int address_type_key)
        {
            Log.LogInformation("Accessing AddressTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_type_key", address_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_type_get", pcol));
        }

        public override AddressTypeData GetByCode(string address_type_code, string entityCode)
        {
            Log.LogInformation("Accessing AddressTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@address_type_code", address_type_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_type_get_c", pcol));
        }

        public override void Insert(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_type_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AddressTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_type_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_type_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_type_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
