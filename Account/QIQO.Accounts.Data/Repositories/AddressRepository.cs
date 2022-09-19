using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AddressRepository : RepositoryBase<AddressData>, IAddressRepository
    {
        private readonly IAccountDbContext entityContext;
        private readonly ILogger<AddressData> _logger;

        public AddressRepository(IAccountDbContext dbc, IAddressMap map, ILogger<AddressData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AddressData> GetAll()
        {
            _logger.LogInformation("Accessing AddressRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressAll"));
        }

        public IEnumerable<AddressData> GetAll(int entityKey, int entityTypeKey)
        {
            _logger.LogInformation("Accessing AddressRepo GetAll by keys function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressAllByEntity", pcol));
        }

        public override AddressData GetByID(int AddressKey)
        {
            _logger.LogInformation("Accessing AddressRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressKey", AddressKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressGet", pcol));
        }

        public override AddressData GetByCode(string address_code, string entityCode)
        {
            _logger.LogInformation("Accessing AddressRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AddressCode", address_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressGetByCompany", pcol));
        }

        public override void Insert(AddressData entity)
        {
            _logger.LogInformation("Accessing AddressRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressData entity)
        {
            _logger.LogInformation("Accessing AddressRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressData entity)
        {
            _logger.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AddressRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AddressRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
