using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class CommentTypeRepository : RepositoryBase<CommentTypeData>,
                                     ICommentTypeRepository
    {
        private readonly IInvoiceDbContext entityContext;
        public CommentTypeRepository(IInvoiceDbContext dbc, ICommentTypeMap map, ILogger<CommentTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CommentTypeData> GetAll()
        {
            Log.LogInformation("Accessing CommentTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_type_all"));
        }

        public override CommentTypeData GetByID(int comment_type_key)
        {
            Log.LogInformation("Accessing CommentTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_type_key", comment_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_type_get", pcol));
        }

        public override CommentTypeData GetByCode(string comment_type_code, string entityCode)
        {
            Log.LogInformation("Accessing CommentTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@comment_type_code", comment_type_code),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_type_get_c", pcol));
        }

        public override void Insert(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CommentTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_type_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CommentTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
