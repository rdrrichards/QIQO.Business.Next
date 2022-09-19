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
        private readonly ILogger<OrderHeaderData> _logger;

        public OrderHeaderRepository(IOrderDbContext dbc, IOrderHeaderMap map, ILogger<OrderHeaderData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<OrderHeaderData> GetAll()
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderAll"));
        }

        public IEnumerable<OrderHeaderData> GetAllOpen(int companyKey)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetAllOpen by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", companyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderOpenByCompany", pcol));
        }
        public IEnumerable<OrderHeaderData> FindAll(int company_key, string pattern)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@Pattern", pattern)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderSearch", pcol));
        }

        //public IEnumerable<OrderHeaderData> GetAll(CompanyData company)
        //{
        //    _logger.LogInformation("Accessing OrderHeaderRepo GetAll by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", company.CompanyKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_company", pcol));
        //}

        public IEnumerable<OrderHeaderData> GetAllOpen(AccountData account)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderOpenByAccount", pcol));
        }

        public IEnumerable<OrderHeaderData> GetAll(AccountData account)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderAllByAccount", pcol));
        }

        public override OrderHeaderData GetByID(int order_header_key)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@OrderKey", order_header_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public override OrderHeaderData GetByCode(string order_header_code, string entity_code)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_num", order_header_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public IEnumerable<OrderHeaderData> GetForInvoice(int company_key, int account_key)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@AccountKey", account_key)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspOrderHeaderGet", pcol));
        }

        public override void Insert(OrderHeaderData entity)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderHeaderData entity)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderHeaderData entity)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_header_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(OrderHeaderData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspOrderHeaderUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
