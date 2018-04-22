using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;

namespace QIQO.Orders.Domain
{
    public class Comment: IModel
    {
        public Comment(CommentData commentData)
        {
            CommentKey = commentData.CommentKey;
            CommentType = (QIQOCommentType)commentData.CommentTypeKey;
            CommentValue = commentData.CommentValue;
            EntityKey = commentData.EntityKey;
            EntityTypeKey = commentData.EntityType;
            AddedUserID = commentData.AuditAddUserId;
            AddedDateTime = commentData.AuditAddDatetime;
            UpdateUserID = commentData.AuditUpdateUserId;
            UpdateDateTime = commentData.AuditUpdateDatetime;
        }
        public int CommentKey { get; private set; }        
        public int EntityKey { get; private set; }        
        public int EntityTypeKey { get; private set; }        
        public QIQOCommentType CommentType { get; private set; }        
        public string CommentValue { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }    }
}
