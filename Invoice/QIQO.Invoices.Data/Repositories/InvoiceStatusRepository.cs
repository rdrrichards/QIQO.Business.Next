using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceStatusRepository : RepositoryBase<InvoiceStatusData>, IInvoiceStatusRepository
    {
        private readonly IInvoiceDbContext entityContext;
        private readonly ILogger<InvoiceStatusData> _logger;

        public InvoiceStatusRepository(IInvoiceDbContext dbc, IInvoiceStatusMap map, ILogger<InvoiceStatusData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<InvoiceStatusData> GetAll()
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceStatusAll"));
        }

        public override InvoiceStatusData GetByID(int invoice_status_key)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@InvoiceStatusKey", invoice_status_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceStatusGet", pcol));
        }

        public override InvoiceStatusData GetByCode(string invoice_status_code, string entity_code)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@InvoiceStatusCode", invoice_status_code),
                Mapper.BuildParam("@CompanyCode", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspInvoiceStatusGet", pcol));
        }

        public override void Insert(InvoiceStatusData entity)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(InvoiceStatusData entity)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceStatusData entity)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceStatusDel", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@InvoiceStatusCode", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceStatusDel", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing InvoiceStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceStatusDel", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(InvoiceStatusData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspInvoiceStatusUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
