using QIQO.Business.Core.Contracts;
using QIQO.Companies.Data;
using System;

namespace QIQO.Companies.Domain
{
    public class EntityRole : IModel
    {
        public EntityRole(EntityRoleData accountRoleData)
        {
            EntityRoleKey = accountRoleData.EntityRoleKey;
            EntityRoleCode = accountRoleData.EntityRoleCode;
            EntityRoleName = accountRoleData.EntityRoleName;
            EntityRoleDesc = accountRoleData.EntityRoleDesc;
            AddedDateTime = accountRoleData.AuditAddDatetime;
            AddedUserID = accountRoleData.AuditAddUserId;
            UpdateDateTime = accountRoleData.AuditUpdateDatetime;
            UpdateUserID = accountRoleData.AuditUpdateUserId;
        }
        public EntityRole(string accountRoleCode, string accountRoleName, string accountRoleDesc)
        {
            EntityRoleCode = accountRoleCode;
            EntityRoleName = accountRoleName;
            EntityRoleDesc = accountRoleDesc;
        }
        public int EntityRoleKey { get; private set; }
        public string EntityRoleCode { get; private set; }
        public string EntityRoleName { get; private set; }
        public string EntityRoleDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
