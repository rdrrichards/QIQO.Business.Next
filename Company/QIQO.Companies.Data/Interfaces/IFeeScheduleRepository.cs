using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Companies.Data
{
    public interface IFeeScheduleRepository : IRepository<FeeScheduleData>
    {
        IEnumerable<FeeScheduleData> GetAll(CompanyData company);
        // IEnumerable<FeeScheduleData> GetAll(ProductData product);
    }
    public interface IEntityEntityRepository : IRepository<EntityEntityData> { }
}
