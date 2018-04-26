using QIQO.Accounts.Data;
using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class CommentType : IModel
    {
        public CommentType(CommentTypeData accountTypeData)
        {
            CommentTypeKey = accountTypeData.CommentTypeKey;
            CommentTypeCode = accountTypeData.CommentTypeCode;
            CommentTypeName = accountTypeData.CommentTypeName;
            CommentTypeDesc = accountTypeData.CommentTypeDesc;
            AddedDateTime = accountTypeData.AuditAddDatetime;
            AddedUserID = accountTypeData.AuditAddUserId;
            UpdateDateTime = accountTypeData.AuditUpdateDatetime;
            UpdateUserID = accountTypeData.AuditUpdateUserId;
        }
        public CommentType(string accountTypeCode, string accountTypeName, string accountTypeDesc)
        {
            CommentTypeCode = accountTypeCode;
            CommentTypeName = accountTypeName;
            CommentTypeDesc = accountTypeDesc;
        }
        public int CommentTypeKey { get; private set; }
        public string CommentTypeCode { get; private set; }
        public string CommentTypeName { get; private set; }
        public string CommentTypeDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
