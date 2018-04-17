using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Data
{
    public class PersonTypeData : CommonData, IEntity
    {
        public int PersonTypeKey { get; set; }
        public string PersonTypeCategory { get; set; }
        public string PersonTypeCode { get; set; }
        public string PersonTypeName { get; set; }
        public string PersonTypeDesc { get; set; }
    }
}