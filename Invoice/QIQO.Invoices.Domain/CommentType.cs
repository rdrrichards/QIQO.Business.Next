using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class CommentType : IModel
    {
        public CommentType(CommentTypeData commentTypeData)
        {
            CommentTypeKey = commentTypeData.CommentTypeKey;
            CommentTypeCategory = commentTypeData.CommentTypeCategory;
            CommentTypeCode = commentTypeData.CommentTypeCode;
            CommentTypeName = commentTypeData.CommentTypeName;
            CommentTypeDesc = commentTypeData.CommentTypeDesc;
            AddedUserID = commentTypeData.AuditAddUserId;
            AddedDateTime = commentTypeData.AuditAddDatetime;
            UpdateUserID = commentTypeData.AuditUpdateUserId;
            UpdateDateTime = commentTypeData.AuditUpdateDatetime;
        }
        public int CommentTypeKey { get; private set; }        
        public string CommentTypeCategory { get; private set; }        
        public string CommentTypeCode { get; private set; }        
        public string CommentTypeName { get; private set; }        
        public string CommentTypeDesc { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
