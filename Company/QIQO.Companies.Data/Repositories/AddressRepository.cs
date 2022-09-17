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
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressAll"));
        }

        public IEnumerable<AddressData> GetAll(int entityKey, int entity_type)
        {
            Log.LogInformation("Accessing AddressRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entity_type)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressAllByEntity", pcol));
        }

        public override AddressData GetByID(int AddressKey)
        {
            Log.LogInformation("Accessing AddressRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressKey", AddressKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressGet", pcol));
        }

        public override AddressData GetByCode(string address_code, string entity_code)
        {
            Log.LogInformation("Accessing AddressRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AddressCode", address_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressGetByCompany", pcol));
        }

        public override void Insert(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressData entity)
        {
            Log.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing AddressRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
