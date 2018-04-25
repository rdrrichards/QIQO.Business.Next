using System;

namespace QIQO.Products.Data
{
    public class AuditLogData : CommonData
    {
        public int AuditLogKey { get; set; }
        public string AuditAction { get; set; }
        public string AuditBusObj { get; set; }
        public DateTime AuditDatetime { get; set; }
        public string AuditUserId { get; set; }
        public string AuditAppName { get; set; }
        public string AuditHostName { get; set; }
        public string AuditComment { get; set; }
        public string AuditDataOld { get; set; }
        public string AuditDataNew { get; set; }
    }
}