using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyFeeScheduleUpdateViewModel
    {
        [Required]
        public int FeeScheduleKey { get; set; }
        [Required]
        public DateTime FeeScheduleStartDate { get; set; }
        public DateTime FeeScheduleEndDate { get; set; }
        [Required]
        public string FeeScheduleTypeCode { get; set; }
        [Required]
        public decimal FeeScheduleValue { get; set; }
        [Required]
        public string UpdateUserID { get; set; }
        [Required]
        public DateTime UpdateDateTime { get; set; }
    }
}
