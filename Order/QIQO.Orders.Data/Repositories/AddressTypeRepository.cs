using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class AddressTypeRepository : RepositoryBase<AddressTypeData>,
                                     IAddressTypeRepository
    {
        private readonly IOrderDbContext entityContext;
        private readonly ILogger<AddressTypeData> _logger;

        public AddressTypeRepository(IOrderDbContext dbc, IAddressTypeMap map, ILogger<AddressTypeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<AddressTypeData> GetAll()
        {
            _logger.LogInformation("Accessing AddressTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeAll"));
        }

        public override AddressTypeData GetByID(int AddressTypeKey)
        {
            _logger.LogInformation("Accessing AddressTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressTypeKey", AddressTypeKey) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeGet", pcol));
        }

        public override AddressTypeData GetByCode(string address_type_code, string entityCode)
        {
            _logger.LogInformation("Accessing AddressTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@AddressTypeCode", address_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspAddressTypeGetByCompany", pcol));
        }

        public override void Insert(AddressTypeData entity)
        {
            _logger.LogInformation("Accessing AddressTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AddressTypeData entity)
        {
            _logger.LogInformation("Accessing AddressTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AddressTypeData entity)
        {
            _logger.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing AddressTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AddressTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing AddressTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(AddressTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspAddressTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
