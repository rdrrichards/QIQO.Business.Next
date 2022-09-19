using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceRepository : RepositoryBase<InvoiceData>, IInvoiceRepository
    {
        private readonly IInvoiceDbContext entityContext;
        private readonly ILogger<InvoiceData> _logger;

        public InvoiceRepository(IInvoiceDbContext dbc, IInvoiceMap map, ILogger<InvoiceData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<InvoiceData> GetAll()
        {
            _logger.LogInformation("Accessing InvoiceRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceAll"));
        }

        //public IEnumerable<InvoiceData> GetAll(int companyKey)
        //{
        //    _logger.LogInformation("Accessing InvoiceRepo GetAll by CompanyData function");
        //    var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", companyKey) };
        //    using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_all_by_company", pcol));
        //}

        public IEnumerable<InvoiceData> GetAll(AccountData account)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetAll by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceOpenByAccount", pcol));
        }
        public IEnumerable<InvoiceData> FindAll(int company_key, string pattern)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CompanyKey", company_key),
                Mapper.BuildParam("@Pattern", pattern)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceSearch", pcol));
        }

        public IEnumerable<InvoiceData> GetAllOpen(int companyKey)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetAllOpen by CompanyData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CompanyKey", companyKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceOpenByCompany", pcol));
        }

        public IEnumerable<InvoiceData> GetAllOpen(AccountData account)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetAllOpen by AccountData function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@AccountKey", account.AccountKey) };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceOpenByAccount", pcol));
        }

        public override InvoiceData GetByID(int invoice_key)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@InvoiceKey", invoice_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceGet", pcol));
        }

        public override InvoiceData GetByCode(string invoice_code, string entity_code)
        {
            _logger.LogInformation("Accessing InvoiceRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@InvoiceCode", invoice_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceGetByCode", pcol));
        }

        public override void Insert(InvoiceData entity)
        {
            _logger.LogInformation("Accessing InvoiceRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(InvoiceData entity)
        {
            _logger.LogInformation("Accessing InvoiceRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceData entity)
        {
            _logger.LogInformation("Accessing InvoiceRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing InvoiceRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@InvoiceCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceDelByCode", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing InvoiceRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(InvoiceData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
