using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Invoices.Data
{
    public interface IFeeScheduleRepository : IRepository<FeeScheduleData>
    {
        IEnumerable<FeeScheduleData> GetAll(AccountData account);
        // IEnumerable<FeeScheduleData> GetAll(CompanyData company);
        // IEnumerable<FeeScheduleData> GetAll(ProductData product);
    }
    public interface IAuditLogRepository : IRepository<AuditLogData> { }
}
