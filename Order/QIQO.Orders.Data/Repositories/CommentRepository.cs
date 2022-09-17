using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class CommentRepository : RepositoryBase<CommentData>, ICommentRepository
    {
        private readonly IOrderDbContext entityContext;

        public CommentRepository(IOrderDbContext dbc, ICommentMap map, ILogger<CommentData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CommentData> GetAll()
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentAll"));
        }

        public IEnumerable<CommentData> GetAll(int entityKey, int entityTypeKey)
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@EntityKey", entityKey),
                Mapper.BuildParam("@EntityTypeKey", entityTypeKey)
            };
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentAllByEntity", pcol));
        }

        public override CommentData GetByID(int comment_key)
        {
            Log.LogInformation("Accessing CommentRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CommentKey", comment_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentGet", pcol));
        }

        public override CommentData GetByCode(string commentCode, string entityCode)
        {
            Log.LogInformation("Accessing CommentRepo GetByCode function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@comment_code", commentCode),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentGetByCompany", pcol));
        }

        public override void Insert(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CommentRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_code", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentDelByCompany", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CommentData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }

}
