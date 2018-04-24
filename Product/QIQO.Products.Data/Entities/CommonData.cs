using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Products.Data
{
    public class CommonData : IEntity
    {
        public string AuditAddUserId { get; set; }
        public DateTime AuditAddDatetime { get; set; }
        public string AuditUpdateUserId { get; set; }
        public DateTime AuditUpdateDatetime { get; set; }
    }
}