using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class CommentMap : MapperBase, ICommentMap
    {
        public CommentData Map(IDataReader record)
        {
            try
            {
                return new CommentData()
                {
                    CommentKey = NullCheck<int>(record["comment_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityType = NullCheck<int>(record["entity_type"]),
                    CommentTypeKey = NullCheck<int>(record["comment_type_key"]),
                    CommentValue = NullCheck<string>(record["comment_value"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CommentMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(CommentData entity) => new List<SqlParameter>
            {
                BuildParam("@comment_key", entity.CommentKey),
                BuildParam("@entity_key", entity.EntityKey),
                BuildParam("@entity_type", entity.EntityType),
                BuildParam("@comment_type_key", entity.CommentTypeKey),
                BuildParam("@comment_value", entity.CommentValue),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CommentData entity) => MapParamsForDelete(entity.CommentKey);

        public List<SqlParameter> MapParamsForDelete(int comment_key) => new List<SqlParameter>
            {
                BuildParam("@comment_key", comment_key),
                GetOutParam()
            };
    }
}
