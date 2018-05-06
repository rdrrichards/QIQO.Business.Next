using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyAddViewModel
    {
        [Required]
        public string CompanyCode { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
        public List<CompanyAddressAddViewModel> CompanyAddressees { get; set; }
        public List<CompanyAttributeAddViewModel> CompanyAttributes { get; set; }
        public List<CompanyFeeScheduleAddViewModel> FeeSchedules { get; set; }
    }
}
