using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Companies.Data
{
    public class FeeScheduleData : CommonData, IEntity
    {
        public int FeeScheduleKey { get; set; }
        public int CompanyKey { get; set; }
        public int AccountKey { get; set; }
        public int ProductKey { get; set; }
        public DateTime FeeScheduleStartDate { get; set; }
        public DateTime FeeScheduleEndDate { get; set; }
        public string FeeScheduleType { get; set; }
        public decimal FeeScheduleValue { get; set; }
        public string ProductCode { get; set; }
        public string ProductDesc { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
    }
}
