using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class CommentMap : MapperBase, ICommentMap
    {
        public CommentData Map(IDataReader record)
        {
            try
            {
                return new CommentData()
                {
                    CommentKey = NullCheck<int>(record["CommentKey"]),
                    EntityKey = NullCheck<int>(record["EntityKey"]),
                    EntityType = NullCheck<int>(record["EntityTypeKey"]),
                    CommentTypeKey = NullCheck<int>(record["CommentTypeKey"]),
                    CommentValue = NullCheck<string>(record["CommentValue"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CommentMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(CommentData entity) => new List<SqlParameter>
            {
                BuildParam("@CommentKey", entity.CommentKey),
                BuildParam("@EntityKey", entity.EntityKey),
                BuildParam("@EntityTypeKey", entity.EntityType),
                BuildParam("@CommentTypeKey", entity.CommentTypeKey),
                BuildParam("@CommentValue", entity.CommentValue),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CommentData entity) => MapParamsForDelete(entity.CommentKey);

        public List<SqlParameter> MapParamsForDelete(int comment_key) => new List<SqlParameter>
            {
                BuildParam("@CommentKey", comment_key),
                GetOutParam()
            };
    }
}
