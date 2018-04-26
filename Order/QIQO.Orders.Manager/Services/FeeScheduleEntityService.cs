using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class FeeScheduleEntityService : IFeeScheduleEntityService
    {
        public FeeSchedule Map(FeeScheduleData feeScheduleData) => new FeeSchedule(feeScheduleData);

        public FeeScheduleData Map(FeeSchedule feeSchedule) => new FeeScheduleData()
        {
            FeeScheduleKey = feeSchedule.FeeScheduleKey,
            CompanyKey = feeSchedule.CompanyKey,
            AccountKey = feeSchedule.AccountKey,
            ProductKey = feeSchedule.ProductKey,
            FeeScheduleStartDate = feeSchedule.FeeScheduleStartDate,
            FeeScheduleEndDate = feeSchedule.FeeScheduleEndDate,
            FeeScheduleType = feeSchedule.FeeScheduleTypeCode,
            FeeScheduleValue = feeSchedule.FeeScheduleValue
        };
    }
}
