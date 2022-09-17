using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class CommentTypeRepository : RepositoryBase<CommentTypeData>,
                                     ICommentTypeRepository
    {
        private readonly IAccountDbContext entityContext;
        public CommentTypeRepository(IAccountDbContext dbc, ICommentTypeMap map, ILogger<CommentTypeData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CommentTypeData> GetAll()
        {
            Log.LogInformation("Accessing CommentTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentTypeAll"));
        }

        public override CommentTypeData GetByID(int comment_type_key)
        {
            Log.LogInformation("Accessing CommentTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CommentTypeKey", comment_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentTypeGet", pcol));
        }

        public override CommentTypeData GetByCode(string comment_type_code, string entityCode)
        {
            Log.LogInformation("Accessing CommentTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CommentTypeCode", comment_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_type_get_c", pcol));
        }

        public override void Insert(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentTypeData entity)
        {
            Log.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            Log.LogInformation("Accessing CommentTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CommentTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            Log.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CommentTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
