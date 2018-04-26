using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
{
    public class CommentTypeEntityService : ICommentTypeEntityService
    {
        public CommentType Map(CommentTypeData commentData) => new CommentType(commentData);
        public CommentTypeData Map(CommentType comment) => new CommentTypeData()
        {
            CommentTypeKey = comment.CommentTypeKey,
            CommentTypeCode = comment.CommentTypeCode,
            CommentTypeName = comment.CommentTypeName,
            CommentTypeDesc = comment.CommentTypeDesc
        };
    }
}
