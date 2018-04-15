using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class Comment : IModel
    {
        public int CommentKey { get; private set; }
        public int EntityKey { get; private set; }
        public int EntityTypeKey { get; private set; }
        public QIQOCommentType CommentType { get; private set; }
        public string CommentValue { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}
