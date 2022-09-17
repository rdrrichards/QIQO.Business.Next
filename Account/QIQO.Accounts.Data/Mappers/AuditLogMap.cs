using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AuditLogMap : MapperBase, IAuditLogMap
    {
        public AuditLogData Map(IDataReader record)
        {
            try
            {
                return new AuditLogData()
                {
                    AuditLogKey = NullCheck<int>(record["LogKey"]),
                    AuditAction = NullCheck<string>(record["Action"]),
                    AuditBusObj = NullCheck<string>(record["BusinessObject"]),
                    AuditDatetime = NullCheck<DateTime>(record["AuditDateTime"]),
                    AuditUserId = NullCheck<string>(record["UserId"]),
                    AuditAppName = NullCheck<string>(record["Application"]),
                    AuditHostName = NullCheck<string>(record["Host"]),
                    AuditComment = NullCheck<string>(record["Comment"]),
                    AuditDataOld = NullCheck<string>(record["DataOld"]),
                    AuditDataNew = NullCheck<string>(record["DataNew"]),
                    //AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    //AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    //AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    //AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AuditLogMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AuditLogData entity) => new List<SqlParameter>
            {
                new SqlParameter("@LogKey", entity.AuditLogKey),
                new SqlParameter("@Action", entity.AuditAction),
                new SqlParameter("@BusinessObject", entity.AuditBusObj),
                new SqlParameter("@AuditDateTime", entity.AuditDatetime),
                new SqlParameter("@UserId", entity.AuditUserId),
                new SqlParameter("@Application", entity.AuditAppName),
                new SqlParameter("@Host", entity.AuditHostName),
                new SqlParameter("@Comment", entity.AuditComment),
                new SqlParameter("@DataOld", entity.AuditDataOld),
                new SqlParameter("@DataNew", entity.AuditDataNew),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AuditLogData entity) => MapParamsForDelete(entity.AuditLogKey);

        public List<SqlParameter> MapParamsForDelete(int LogKey) => new List<SqlParameter>
            {
                new SqlParameter("@LogKey", LogKey),
                GetOutParam()
            };
    }
}
