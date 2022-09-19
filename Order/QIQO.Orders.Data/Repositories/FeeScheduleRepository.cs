using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class FeeScheduleRepository : RepositoryBase<FeeScheduleData>, IFeeScheduleRepository
    {
        private readonly IOrderDbContext entityContext;
        private readonly ILogger<FeeScheduleData> _logger;

        public FeeScheduleRepository(IOrderDbContext dbc, IFeeScheduleMap map, ILogger<FeeScheduleData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<FeeScheduleData> GetAll()
        {
            _logger.LogInformation("Accessing FeeScheduleRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspFeeScheduleAll"));
        }

        public IEnumerable<FeeScheduleData> GetAll(AccountData account)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo GetAll by Account function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspFeeScheduleAllByAccount", pcol));
        }

        //public IEnumerable<FeeScheduleData> GetAll(CompanyData company)
        //{
        //    _logger.LogInformation("Accessing FeeScheduleRepo GetAll by Company function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", company.CompanyKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspFeeScheduleAllByCompany", pcol));
        //}

        public IEnumerable<FeeScheduleData> GetAll(ProductData product)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo GetAll by Product function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@ProductKey", product.ProductKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspFeeScheduleAllByProduct", pcol));
        }

        public override FeeScheduleData GetByID(int fee_schedule_key)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@FeeScheduleKey", fee_schedule_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspFeeScheduleGet", pcol));
        }

        public override FeeScheduleData GetByCode(string fee_schedule_code, string entityCode)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@fee_schedule_code", fee_schedule_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_get_c", pcol));
        }

        public override void Insert(FeeScheduleData entity)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(FeeScheduleData entity)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(FeeScheduleData entity)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspFeeScheduleDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@fee_schedule_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_fee_schedule_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing FeeScheduleRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspFeeScheduleDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(FeeScheduleData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspFeeScheduleUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }

}
