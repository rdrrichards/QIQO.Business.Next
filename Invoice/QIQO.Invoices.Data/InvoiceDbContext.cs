using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public interface IInvoiceDbContext : IDbContext { }
    public class InvoiceDbContext : DbContextBase, IInvoiceDbContext //, IDisposable
    {
        public InvoiceDbContext() : this(null, null)
        {

        }
        public InvoiceDbContext(ILogger<InvoiceDbContext> logger, IConfiguration configuration) : base(logger, configuration.GetConnectionString("InvoiceManagement"))
        {
            // Log.LogInformation("Hello from the AccountDbContext!");
        }

        public override int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand(procedureName, _connection) { CommandType = CommandType.StoredProcedure };
            int ret_val;

            foreach (var sparam in parameters)
                cmd.Parameters.Add(BuildParameter(sparam));

            try
            {
                _connection.Open();
                ret_val = cmd.ExecuteNonQuery();
                _connection.Close();
                if (cmd.Parameters["@key"] != null)
                {
                    int key = (int)cmd.Parameters["@key"].Value;
                    if (key > ret_val)
                        return key;
                }
                return ret_val;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }

        }
    }

}
