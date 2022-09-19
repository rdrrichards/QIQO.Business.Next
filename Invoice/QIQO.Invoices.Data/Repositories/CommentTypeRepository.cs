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
        private readonly ILogger<CommentTypeData> _logger;

        public CommentTypeRepository(IInvoiceDbContext dbc, ICommentTypeMap map, ILogger<CommentTypeData> logger) : base(map)
        {
            entityContext = dbc;
            _logger = logger;
        }

        public override IEnumerable<CommentTypeData> GetAll()
        {
            _logger.LogInformation("Accessing CommentTypeRepo GetAll function");
            using (entityContext) return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentTypeAll"));
        }

        public override CommentTypeData GetByID(int comment_type_key)
        {
            _logger.LogInformation("Accessing CommentTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CommentTypeKey", comment_type_key) };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("uspCommentTypeGet", pcol));
        }

        public override CommentTypeData GetByCode(string comment_type_code, string entityCode)
        {
            _logger.LogInformation("Accessing CommentTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@CommentTypeCode", comment_type_code),
                Mapper.BuildParam("@CompanyCode", entityCode)
            };
            using (entityContext) return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_type_get_c", pcol));
        }

        public override void Insert(CommentTypeData entity)
        {
            _logger.LogInformation("Accessing CommentTypeRepo Insert function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentTypeData entity)
        {
            _logger.LogInformation("Accessing CommentTypeRepo Save function");
            if (entity is not null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentTypeData entity)
        {
            _logger.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeDelete", Mapper.MapParamsForDelete(entity));
        }

        public override void DeleteByCode(string entityCode)
        {
            _logger.LogInformation("Accessing CommentTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@CommentTypeCode", entityCode) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext) entityContext.ExecuteProcedureNonQuery("usp_comment_type_del_c", pcol);
        }

        public override void DeleteByID(int entityKey)
        {
            _logger.LogInformation("Accessing CommentTypeRepo Delete function");
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeDelete", Mapper.MapParamsForDelete(entityKey));
        }

        private void Upsert(CommentTypeData entity)
        {
            using (entityContext) entityContext.ExecuteProcedureNonQuery("uspCommentTypeUpsert", Mapper.MapParamsForUpsert(entity));
        }
    }
}
