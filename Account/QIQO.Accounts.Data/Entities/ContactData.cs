namespace QIQO.Accounts.Data
{
    public class ContactData : CommonData
    {
        public int ContactKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public int ContactTypeKey { get; set; }
        public string ContactValue { get; set; }
        public int ContactDefaultFlg { get; set; }
        public int ContactActiveFlg { get; set; }
    }
}
