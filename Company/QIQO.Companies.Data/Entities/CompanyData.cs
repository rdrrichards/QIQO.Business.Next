using QIQO.Business.Core.Contracts;

namespace QIQO.Companies.Data
{
    public class CompanyData : CommonData, IEntity
    {
        public int CompanyKey { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
    }
}
