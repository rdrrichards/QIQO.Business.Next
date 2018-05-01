using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class CommentRepository : RepositoryBase<CommentData>, ICommentRepository
    {
        private readonly ICompanyDbContext entityContext;

        public CommentRepository(ICompanyDbContext dbc, ICommentMap map, ILogger<CommentData> log) : base(log, map)
        {
            entityContext = dbc;
        }
        public override IEnumerable<CommentData> GetAll()
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_all"));
        }

        public IEnumerable<CommentData> GetAll(int entityKey, int entityTypeKey)
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@entity_key", entityKey),
                Mapper.BuildParam("@entity_type_key", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_all_by_entity", pcol));
        }

        public override CommentData GetByID(int comment_key)
        {
            Log.LogInformation("Accessing CommentRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_key", comment_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_get", pcol));
        }

        public override CommentData GetByCode(string commentCode, string entityCode)
        {
            Log.LogInformation("Accessing CommentRepo GetByCode function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@comment_code", commentCode),
                Mapper.BuildParam("@company_code", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_get_c", pcol));
        }

        public override void Insert(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CommentRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CommentData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_ups", Mapper.MapParamsForUpsert(entity));
        }
    }
}
