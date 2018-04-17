using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Data
{
    public class CommentTypeData : CommonData, IEntity
    {
        public int CommentTypeKey { get; set; }
        public string CommentTypeCategory { get; set; }
        public string CommentTypeCode { get; set; }
        public string CommentTypeName { get; set; }
        public string CommentTypeDesc { get; set; }
    }
}