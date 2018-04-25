using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class CommentTypeMap : MapperBase, ICommentTypeMap
    {
        public CommentTypeData Map(IDataReader record)
        {
            try
            {
                return new CommentTypeData()
                {
                    CommentTypeKey = NullCheck<int>(record["comment_type_key"]),
                    CommentTypeCode = NullCheck<string>(record["comment_type_code"]),
                    CommentTypeName = NullCheck<string>(record["comment_type_name"]),
                    CommentTypeDesc = NullCheck<string>(record["comment_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(CommentTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@comment_type_key", entity.CommentTypeKey),
                BuildParam("@comment_type_code", entity.CommentTypeCode),
                BuildParam("@comment_type_name", entity.CommentTypeName),
                BuildParam("@comment_type_desc", entity.CommentTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CommentTypeData entity) => MapParamsForDelete(entity.CommentTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@comment_type_key", accountTypeKey),
                GetOutParam()
            };
    }
}
