using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderHeaderRepository : RepositoryBase<OrderHeaderData>, IOrderHeaderRepository
    {
        private readonly IOrderDbContext entityContext;

        public OrderHeaderRepository(IOrderDbContext dbc, IOrderHeaderMap map, ILogger<OrderHeaderData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<OrderHeaderData> GetAll()
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderAll"));
        }

        public IEnumerable<OrderHeaderData> GetAllOpen(int companyKey)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAllOpen by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", companyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderOpenByCompany", pcol));
        }
        public IEnumerable<OrderHeaderData> FindAll(int company_key, string pattern)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@Pattern", pattern)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderSearch", pcol));
        }

        //public IEnumerable<OrderHeaderData> GetAll(CompanyData company)
        //{
        //    Log.LogInformation("Accessing OrderHeaderRepo GetAll by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", company.CompanyKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_company", pcol));
        //}

        public IEnumerable<OrderHeaderData> GetAllOpen(AccountData account)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderOpenByAccount", pcol));
        }

        public IEnumerable<OrderHeaderData> GetAll(AccountData account)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderAllByAccount", pcol));
        }

        public override OrderHeaderData GetByID(int order_header_key)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderKey", order_header_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public override OrderHeaderData GetByCode(string order_header_code, string entity_code)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_num", order_header_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public IEnumerable<OrderHeaderData> GetForInvoice(int company_key, int account_key)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@AccountKey", account_key)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public override void Insert(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing OrderHeaderRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_header_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(OrderHeaderData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
