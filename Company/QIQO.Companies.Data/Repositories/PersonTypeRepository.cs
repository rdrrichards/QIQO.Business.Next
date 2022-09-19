using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class PersonTypeRepository : RepositoryBase<PersonTypeData>,
                                     IPersonTypeRepository
    {
        private readonly ICompanyDbContext entityContext;
        private readonly ILogger<PersonTypeData> _logger;

        public PersonTypeRepository(ICompanyDbContext dbc, IPersonTypeMap map, ILogger<PersonTypeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<PersonTypeData> GetAll()
        {
            _logger.LogInformation("Accessing PersonTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonTypeAll"));
        }

        public override PersonTypeData GetByID(int person_type_key)
        {
            _logger.LogInformation("Accessing PersonTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonTypeKey", person_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspPersonTypeGet", pcol));
        }

        public override PersonTypeData GetByCode(string person_type_code, string entityCode)
        {
            _logger.LogInformation("Accessing PersonTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@PersonTypeCode", person_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_type_get_c", pcol));
        }

        public override void Insert(PersonTypeData entity)
        {
            _logger.LogInformation("Accessing PersonTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(PersonTypeData entity)
        {
            _logger.LogInformation("Accessing PersonTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonTypeData entity)
        {
            _logger.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing PersonTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@PersonTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_person_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing PersonTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(PersonTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspPersonTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
