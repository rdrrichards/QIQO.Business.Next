using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class CommentEntityService : ICommentEntityService
    {
        public Comment Map(CommentData comment_data)
        {
            Comment comment = new Comment()
            {
                //CommentKey = comment_data.CommentKey,
                //CommentType = (QIQOCommentType)comment_data.CommentTypeKey,
                //CommentValue = comment_data.CommentValue,
                //EntityKey = comment_data.EntityKey,
                //EntityTypeKey = comment_data.EntityType,
                //AddedUserID = comment_data.AuditAddUserId,
                //AddedDateTime = comment_data.AuditAddDatetime,
                //UpdateUserID = comment_data.AuditUpdateUserId,
                //UpdateDateTime = comment_data.AuditUpdateDatetime
            };

            return comment;
        }
        public CommentData Map(Comment comment)
        {
            CommentData comment_data = new CommentData()
            {
                CommentKey = comment.CommentKey,
                CommentTypeKey = (int)comment.CommentType,
                CommentValue = comment.CommentValue,
                EntityKey = comment.EntityKey,
                EntityType = comment.EntityTypeKey
            };

            return comment_data;
        }
    }
}
