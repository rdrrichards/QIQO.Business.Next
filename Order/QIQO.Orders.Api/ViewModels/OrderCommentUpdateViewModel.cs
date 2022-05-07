using QIQO.Orders.Domain;

namespace QIQO.Business.Api.Orders
{
    public class OrderCommentUpdateViewModel
    {
        public int CommentKey { get; private set; }
        public int EntityKey { get; private set; }
        public int EntityTypeKey { get; private set; }
        public QIQOCommentType CommentType { get; private set; }
        public string CommentValue { get; private set; } = string.Empty;
        public string UpdateUserID { get; private set; } = string.Empty;
        public DateTime UpdateDateTime { get; private set; }
    }
}
