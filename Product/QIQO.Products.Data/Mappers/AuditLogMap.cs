using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Products.Data
{
    public class AuditLogMap : MapperBase, IAuditLogMap
    {
        public AuditLogData Map(IDataReader record)
        {
            try
            {
                return new AuditLogData()
                {
                    AuditLogKey = NullCheck<int>(record["AuditLogKey"]),
                    AuditAction = NullCheck<string>(record["AuditAction"]),
                    AuditBusObj = NullCheck<string>(record["AuditBusObj"]),
                    AuditDatetime = NullCheck<DateTime>(record["AuditDatetime"]),
                    AuditUserId = NullCheck<string>(record["AuditUserId"]),
                    AuditAppName = NullCheck<string>(record["AuditAppName"]),
                    AuditHostName = NullCheck<string>(record["AuditHostName"]),
                    AuditComment = NullCheck<string>(record["AuditComment"]),
                    AuditDataOld = NullCheck<string>(record["AuditDataOld"]),
                    AuditDataNew = NullCheck<string>(record["AuditDataNew"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDatetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDatetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AuditLogMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AuditLogData entity) => new List<SqlParameter>
            {
                new SqlParameter("@AuditLogKey", entity.AuditLogKey),
                new SqlParameter("@AuditAction", entity.AuditAction),
                new SqlParameter("@AuditBusObj", entity.AuditBusObj),
                new SqlParameter("@AuditDatetime", entity.AuditDatetime),
                new SqlParameter("@AuditUserId", entity.AuditUserId),
                new SqlParameter("@AuditAppName", entity.AuditAppName),
                new SqlParameter("@AuditHostName", entity.AuditHostName),
                new SqlParameter("@AuditComment", entity.AuditComment),
                new SqlParameter("@AuditDataOld", entity.AuditDataOld),
                new SqlParameter("@AuditDataNew", entity.AuditDataNew),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AuditLogData entity) => MapParamsForDelete(entity.AuditLogKey);

        public List<SqlParameter> MapParamsForDelete(int LogKey) => new List<SqlParameter>
            {
                new SqlParameter("@AuditLogKey", LogKey),
                GetOutParam()
            };
    }
}
