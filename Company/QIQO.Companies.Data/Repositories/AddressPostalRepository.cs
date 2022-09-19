using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AddressPostalRepository : RepositoryBase<AddressPostalData>,
                                     IAddressPostalRepository
    {
        private readonly ICompanyDbContext entityContext;
        private readonly ILogger<AddressPostalData> _logger;

        public AddressPostalRepository(ICompanyDbContext dbc, IAddressPostalMap map, ILogger<AddressPostalData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AddressPostalData> GetAll()
        {
            _logger.LogInformation("Accessing AddressPostalRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressPostalAll"));
        }

        public override AddressPostalData GetByID(int address_postal_key)
        {
            _logger.LogInformation("Accessing AddressPostalRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@address_postal_key", address_postal_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressPostalGet", pcol));
        }

        public override AddressPostalData GetByCode(string address_code, string entityCode)
        {
            _logger.LogInformation("Accessing AddressPostalRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AddressCode", address_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_address_postal_get_c", pcol));
        }

        public override void Insert(AddressPostalData entity)
        {
            _logger.LogInformation("Accessing AddressPostalRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressPostalData entity)
        {
            _logger.LogInformation("Accessing AddressPostalRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressPostalData entity)
        {
            _logger.LogInformation("Accessing AddressPostalRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressPostalDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AddressPostalRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_address_postal_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AddressPostalRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressPostalDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressPostalData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressPostalUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
