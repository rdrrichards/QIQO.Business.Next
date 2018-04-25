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
                    AuditLogKey = NullCheck<int>(record["audit_log_key"]),
                    AuditAction = NullCheck<string>(record["audit_action"]),
                    AuditBusObj = NullCheck<string>(record["audit_bus_obj"]),
                    AuditDatetime = NullCheck<DateTime>(record["audit_datetime"]),
                    AuditUserId = NullCheck<string>(record["audit_user_id"]),
                    AuditAppName = NullCheck<string>(record["audit_app_name"]),
                    AuditHostName = NullCheck<string>(record["audit_host_name"]),
                    AuditComment = NullCheck<string>(record["audit_comment"]),
                    AuditDataOld = NullCheck<string>(record["audit_data_old"]),
                    AuditDataNew = NullCheck<string>(record["audit_data_new"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AuditLogMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AuditLogData entity) => new List<SqlParameter>
            {
                new SqlParameter("@audit_log_key", entity.AuditLogKey),
                new SqlParameter("@audit_action", entity.AuditAction),
                new SqlParameter("@audit_bus_obj", entity.AuditBusObj),
                new SqlParameter("@audit_datetime", entity.AuditDatetime),
                new SqlParameter("@audit_user_id", entity.AuditUserId),
                new SqlParameter("@audit_app_name", entity.AuditAppName),
                new SqlParameter("@audit_host_name", entity.AuditHostName),
                new SqlParameter("@audit_comment", entity.AuditComment),
                new SqlParameter("@audit_data_old", entity.AuditDataOld),
                new SqlParameter("@audit_data_new", entity.AuditDataNew),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AuditLogData entity) => MapParamsForDelete(entity.AuditLogKey);

        public List<SqlParameter> MapParamsForDelete(int audit_log_key) => new List<SqlParameter>
            {
                new SqlParameter("@audit_log_key", audit_log_key),
                GetOutParam()
            };
    }
}
