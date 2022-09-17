using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AddressTypeRepository : RepositoryBase<AddressTypeData>,
                                     IAddressTypeRepository
    {
        private readonly IAccountDbContext entityContext;
        public AddressTypeRepository(IAccountDbContext dbc, IAddressTypeMap map, ILogger<AddressTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AddressTypeData> GetAll()
        {
            Log.LogInformation("Accessing AddressTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeAll"));
        }

        public override AddressTypeData GetByID(int AddressTypeKey)
        {
            Log.LogInformation("Accessing AddressTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressTypeKey", AddressTypeKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeGet", pcol));
        }

        public override AddressTypeData GetByCode(string address_type_code, string entityCode)
        {
            Log.LogInformation("Accessing AddressTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AddressTypeCode", address_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeGetByCompany", pcol));
        }

        public override void Insert(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressTypeData entity)
        {
            Log.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing AddressTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
