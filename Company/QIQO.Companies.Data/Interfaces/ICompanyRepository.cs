using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Companies.Data
{
    public interface ICompanyRepository : IRepository<CompanyData>
    {
        IEnumerable<CompanyData> GetAll(PersonData person);
        string GetNextNumber(CompanyData company, int number_type);
    }

}
