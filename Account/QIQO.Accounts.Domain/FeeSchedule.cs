using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Accounts.Domain
{
    public class FeeSchedule : IModel
    {
        public int FeeScheduleKey { get; private set; }
        public int CompanyKey { get; private set; }
        public int AccountKey { get; private set; }
        public int ProductKey { get; private set; }
        public DateTime FeeScheduleStartDate { get; private set; }
        public DateTime FeeScheduleEndDate { get; private set; }
        public string FeeScheduleTypeCode { get; private set; }
        public decimal FeeScheduleValue { get; private set; }
        public string ProductDesc { get; private set; }
        public string ProductCode { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
        public string AccountName { get; private set; }
        public string AccountCode { get; private set; }
    }
}
