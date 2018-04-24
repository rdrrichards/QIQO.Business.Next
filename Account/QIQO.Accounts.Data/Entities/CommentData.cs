namespace QIQO.Accounts.Data
{
    public class CommentData : CommonData
    {
        public int CommentKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityType { get; set; }
        public int CommentTypeKey { get; set; }
        public string CommentValue { get; set; }
    }
}
