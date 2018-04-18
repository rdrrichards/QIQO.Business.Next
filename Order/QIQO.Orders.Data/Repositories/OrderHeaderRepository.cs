using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class OrderHeaderRepository : RepositoryBase<OrderHeaderData>, IOrderHeaderRepository
    {
        private IOrderDbContext entity_context;

        public OrderHeaderRepository(IOrderDbContext dbc, IOrderHeaderMap map, ILogger<OrderHeaderData> log) : base(log, map)
        {
            entity_context = dbc;
        }

        public override IEnumerable<OrderHeaderData> GetAll()
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll function");
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all"));
            }
        }

        //public IEnumerable<OrderHeaderData> GetAllOpen(CompanyData company)
        //{
        //    Log.LogInformation("Accessing OrderHeaderRepo GetAllOpen by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
        //    using (entity_context)
        //    {
        //        return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_open_by_company", pcol));
        //    }
        //}
        public IEnumerable<OrderHeaderData> FindAll(int company_key, string pattern)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll function");
            using (entity_context)
            {
                var pcol = new List<SqlParameter>() {
                    Mapper.BuildParam("@company_key", company_key),
                    Mapper.BuildParam("@test_pattern", pattern)
                };
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_find", pcol));
            }
        }

        //public IEnumerable<OrderHeaderData> GetAll(CompanyData company)
        //{
        //    Log.LogInformation("Accessing OrderHeaderRepo GetAll by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
        //    using (entity_context)
        //    {
        //        return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_company", pcol));
        //    }
        //}

        public IEnumerable<OrderHeaderData> GetAllOpen(AccountData account)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_open_by_account", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetAll(AccountData account)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_all_by_account", pcol));
            }
        }

        public override OrderHeaderData GetByID(int order_header_key)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_key", order_header_key) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get", pcol));
            }
        }

        public override OrderHeaderData GetByCode(string order_header_code, string entity_code)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@order_num", order_header_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get_c", pcol));
            }
        }

        public IEnumerable<OrderHeaderData> GetForInvoice(int company_key, int account_key)
        {
            Log.LogInformation("Accessing OrderHeaderRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@account_key", account_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_order_header_get_for_invoice", pcol));
            }
        }

        public override void Insert(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(OrderHeaderData entity)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing OrderHeaderRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@order_header_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing OrderHeaderRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(OrderHeaderData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_order_header_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}
