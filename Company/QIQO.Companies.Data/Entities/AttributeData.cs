namespace QIQO.Companies.Data
{
    public class AttributeData : CommonData
    {
        public int AttributeKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public int AttributeTypeKey { get; set; }
        public string AttributeValue { get; set; }
        public int AttributeDataTypeKey { get; set; }
        public string AttributeDisplayFormat { get; set; }
    }
}
