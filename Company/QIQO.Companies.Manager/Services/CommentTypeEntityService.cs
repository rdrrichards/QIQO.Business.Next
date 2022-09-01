using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Companies.Manager
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
