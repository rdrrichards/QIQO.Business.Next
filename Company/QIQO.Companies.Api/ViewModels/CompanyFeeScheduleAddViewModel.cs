using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyFeeScheduleAddViewModel
    {
        [Required]
        public int CompanyKey { get; set; }
        [Required]
        public DateTime FeeScheduleStartDate { get; set; }
        public DateTime FeeScheduleEndDate { get; set; }
        [Required]
        public string FeeScheduleTypeCode { get; set; }
        [Required]
        public decimal FeeScheduleValue { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string AddedUserID { get; set; }
        [Required]
        public DateTime AddedDateTime { get; set; }
    }
}
