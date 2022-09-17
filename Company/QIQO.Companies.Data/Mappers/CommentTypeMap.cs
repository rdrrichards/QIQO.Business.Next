using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class CommentTypeMap : MapperBase, ICommentTypeMap
    {
        public CommentTypeData Map(IDataReader record)
        {
            try
            {
                return new CommentTypeData()
                {
                    CommentTypeKey = NullCheck<int>(record["CommentTypeKey"]),
                    CommentTypeCode = NullCheck<string>(record["CommentTypeCode"]),
                    CommentTypeName = NullCheck<string>(record["CommentTypeName"]),
                    CommentTypeDesc = NullCheck<string>(record["CommentTypeDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(CommentTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@CommentTypeKey", entity.CommentTypeKey),
                BuildParam("@CommentTypeCode", entity.CommentTypeCode),
                BuildParam("@CommentTypeName", entity.CommentTypeName),
                BuildParam("@CommentTypeDescription", entity.CommentTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(CommentTypeData entity) => MapParamsForDelete(entity.CommentTypeKey);

        public List<SqlParameter> MapParamsForDelete(int accountTypeKey) => new List<SqlParameter>
            {
                BuildParam("@CommentTypeKey", accountTypeKey),
                GetOutParam()
            };
    }
}
