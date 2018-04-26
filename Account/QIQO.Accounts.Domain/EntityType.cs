using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class EntityType : IModel
    {
        public EntityType(EntityTypeData accountTypeData)
        {
            EntityTypeKey = accountTypeData.EntityTypeKey;
            EntityTypeCode = accountTypeData.EntityTypeCode;
            EntityTypeName = accountTypeData.EntityTypeName;
            EntityTypeDesc = accountTypeData.EntityTypeDesc;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            AddedUserID = accountTypeData.AuditAddUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
        }
        public EntityType(string accountTypeCode, string accountTypeName, string accountTypeDesc)
        {
            EntityTypeCode = accountTypeCode;
            EntityTypeName = accountTypeName;
            EntityTypeDesc = accountTypeDesc;
        }
        public int EntityTypeKey { get; private set; }
        public string EntityTypeCode { get; private set; }
        public string EntityTypeName { get; private set; }
        public string EntityTypeDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
