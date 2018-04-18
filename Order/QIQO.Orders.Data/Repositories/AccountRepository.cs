using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class AccountRepository : RepositoryBase<AccountData>,
                                     IAccountRepository
    {
        private IOrderDbContext entityContext;

        public AccountRepository(IOrderDbContext dbc, IAccountMap map, ILogger<AccountData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<AccountData> GetAll()
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_all"));
            }
        }

        public IEnumerable<AccountData> GetAll(PersonData employee)
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_key", employee.PersonKey) };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_all_by_person", pcol));
            }
        }

        public IEnumerable<AccountData> FindAll(int company_key, string pattern)
        {
            Log.LogInformation("Accessing AccountRepo GetAll function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", company_key),
                Mapper.BuildParam("@account_pattern", pattern)
            };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_find", pcol));
            }
        }

        public override AccountData GetByID(int account_key)
        {
            Log.LogInformation("Accessing AccountRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_key", account_key) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get", pcol));
            }
        }

        public override AccountData GetByCode(string account_code, string entity_code)
        {
            Log.LogInformation("Accessing AccountRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@account_code", account_code),
                Mapper.BuildParam("@company_code", entity_code)
            };

            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_account_get_c", pcol));
            }
        }

        public override void Insert(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(AccountData entity)
        {
            Log.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing AccountRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@account_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_account_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing AccountRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_account_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(AccountData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_account_ups", Mapper.MapParamsForUpsert(entity));
            }
        }

        public string GetNextNumber(AccountData account, int entity_desc)
        {
            Log.LogInformation("Accessing AccountRepo GetNextNumber function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@entity_key", account.AccountKey) };
            using (entityContext)
            {
                switch (entity_desc)
                {
                    case 2:
                        return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_order_num", pcol);
                    case 1:
                        return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_invoice_num", pcol);
                    case 6:
                        return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_contact_num", pcol);
                    default:
                        return "";
                }
                //if (entity_desc == 2)
                //    return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_order_num", pcol);
                //else
                //    return entityContext.ExecuteSqlStatementAsScalar<string>("usp_get_next_invoice_num", pcol);
            }
        }
    }
}
