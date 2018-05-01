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

        public InvoiceStatusRepository(IInvoiceDbContext dbc, IInvoiceStatusMap map, ILogger<InvoiceStatusData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<InvoiceStatusData> GetAll()
        {
            Log.LogInformation("Accessing InvoiceStatusRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_status_all"));
        }

        public override InvoiceStatusData GetByID(int invoice_status_key)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_status_key", invoice_status_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_status_get", pcol));
        }

        public override InvoiceStatusData GetByCode(string invoice_status_code, string entity_code)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@invoice_status_code", invoice_status_code),
                Mapper.BuildParam("@company_code", entity_code)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_invoice_status_get_c", pcol));
        }

        public override void Insert(InvoiceStatusData entity)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(InvoiceStatusData entity)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(InvoiceStatusData entity)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_status_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@invoice_status_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_status_del_c", pcol);
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing InvoiceStatusRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_status_del", Mapper.MapParamsForDelete(entity_key));
        }

        private void Upsert(InvoiceStatusData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_invoice_status_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
