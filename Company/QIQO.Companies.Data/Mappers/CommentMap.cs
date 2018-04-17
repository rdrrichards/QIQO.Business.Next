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

        public List<SqlParameter> MapParamsForUpsert(CommentData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@comment_key", entity.CommentKey));
            sql_params.Add(BuildParam("@entity_key", entity.EntityKey));
            sql_params.Add(BuildParam("@entity_type", entity.EntityType));
            sql_params.Add(BuildParam("@comment_type_key", entity.CommentTypeKey));
            sql_params.Add(BuildParam("@comment_value", entity.CommentValue));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(CommentData entity)
        {
            return MapParamsForDelete(entity.CommentKey);
        }

        public List<SqlParameter> MapParamsForDelete(int comment_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(BuildParam("@comment_key", comment_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    }
}
