using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data.Repositories
{
    public class InvoiceRepository : RepositoryBase<InvoiceData>, IInvoiceRepository
    {
        private IInvoiceDbContext entityContext;

        public InvoiceRepository(IInvoiceDbContext dbc, IInvoiceMap map, ILogger<InvoiceData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<InvoiceData> GetAll()
        {
            Log.LogInformation("Accessing InvoiceRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_all"));
            }
        }

        //public IEnumerable<InvoiceData> GetAll(CompanyData company)
        //{
        //    Log.LogInformation("Accessing InvoiceRepo GetAll by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
        //    using (entity_context)
        //    {
        //        return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_all_by_company", pcol));
        //    }
        //}

        public IEnumerable<InvoiceData> GetAll(AccountData account)
        {
            Log.LogInformation("Accessing InvoiceRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_all_by_account", pcol));
            }
        }
        public IEnumerable<InvoiceData> FindAll(int company_key, string pattern)
        {
            Log.LogInformation("Accessing InvoiceRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@test_pattern", pattern)
            };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_find", pcol));
            }
        }

        //public IEnumerable<InvoiceData> GetAllOpen(CompanyData company)
        //{
        //    Log.LogInformation("Accessing InvoiceRepo GetAllOpen by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", company.CompanyKey) };
        //    using (entity_context)
        //    {
        //        return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_invoice_open_by_company", pcol));
        //    }
        //}

        public IEnumerable<InvoiceData> GetAllOpen(AccountData account)
        {
            Log.LogInformation("Accessing InvoiceRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account.AccountKey) };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_open_by_account", pcol));
            }
        }

        public override InvoiceData GetByID(int invoice_key)
        {
            Log.LogInformation("Accessing InvoiceRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_key", invoice_key) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_get", pcol));
            }
        }

        public override InvoiceData GetByCode(string invoice_code, string entity_code)
        {
            Log.LogInformation("Accessing InvoiceRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@invoice_code", invoice_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_get_c", pcol));
            }
        }

        public override void Insert(InvoiceData entity)
        {
            Log.LogInformation("Accessing InvoiceRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(InvoiceData entity)
        {
            Log.LogInformation("Accessing InvoiceRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceData entity)
        {
            Log.LogInformation("Accessing InvoiceRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_invoice_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing InvoiceRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_invoice_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing InvoiceRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_invoice_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(InvoiceData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_invoice_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}
