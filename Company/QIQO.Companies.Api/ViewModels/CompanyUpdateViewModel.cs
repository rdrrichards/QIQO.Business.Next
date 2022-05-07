using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyUpdateViewModel
    {
        [Required]
        public int CompanyKey { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
        public List<CompanyAddressUpdateViewModel> CompanyAddressees { get; set; }
        public List<CompanyAttributeUpdateViewModel> CompanyAttributes { get; set; }
        public List<CompanyFeeScheduleUpdateViewModel> FeeSchedules { get; set; }
    }
}
