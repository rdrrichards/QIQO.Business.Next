using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class FeeScheduleRepository : RepositoryBase<FeeScheduleData>, IFeeScheduleRepository
    {
        private ICompanyDbContext entityContext;

        public FeeScheduleRepository(ICompanyDbContext dbc, IFeeScheduleMap map, ILogger<FeeScheduleData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<FeeScheduleData> GetAll()
        {
            Log.LogInformation("Accessing FeeScheduleRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_all"));
        }

        //public IEnumerable<FeeScheduleData> GetAll(AccountData account)
        //{
        //    Log.LogInformation("Accessing FeeScheduleRepo GetAll by Account function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_all_by_account", pcol));
        //}

        public IEnumerable<FeeScheduleData> GetAll(CompanyData company)
        {
            Log.LogInformation("Accessing FeeScheduleRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", company.CompanyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_all_by_company", pcol));
        }

        //public IEnumerable<FeeScheduleData> GetAll(ProductData product)
        //{
        //    Log.LogInformation("Accessing FeeScheduleRepo GetAll by Product function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@product_key", product.ProductKey) };
        //    using (entityContext)
        //    {
        //        return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_all_by_product", pcol));
        //    }
        //}

        public override FeeScheduleData GetByID(int fee_schedule_key)
        {
            Log.LogInformation("Accessing FeeScheduleRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@fee_schedule_key", fee_schedule_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_get", pcol));
        }

        public override FeeScheduleData GetByCode(string fee_schedule_code, string entityCode)
        {
            Log.LogInformation("Accessing FeeScheduleRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@fee_schedule_code", fee_schedule_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_fee_schedule_get_c", pcol));
        }

        public override void Insert(FeeScheduleData entity)
        {
            Log.LogInformation("Accessing FeeScheduleRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(FeeScheduleData entity)
        {
            Log.LogInformation("Accessing FeeScheduleRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(FeeScheduleData entity)
        {
            Log.LogInformation("Accessing FeeScheduleRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_fee_schedule_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing FeeScheduleRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@fee_schedule_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_fee_schedule_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing FeeScheduleRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_fee_schedule_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(FeeScheduleData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_fee_schedule_ups", Mapper.MapParamsForUpsert(entity));
        }
    }

}
