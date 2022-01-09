using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyAddressAddViewModel : CompanyAddressBaseViewModel
    {
        [Required]
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
