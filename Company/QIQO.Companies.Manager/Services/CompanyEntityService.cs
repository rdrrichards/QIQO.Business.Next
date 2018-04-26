using QIQO.Companies.Data;
using QIQO.Companies.Domain;

namespace QIQO.Accounts.Manager
{
    public class CompanyEntityService : ICompanyEntityService
    {
        public Company Map(CompanyData companyData) => new Company(companyData);

        public CompanyData Map(Company company) => new CompanyData()
        {
            CompanyKey = company.CompanyKey,
            CompanyCode = company.CompanyCode,
            CompanyName = company.CompanyName,
            CompanyDesc = company.CompanyDesc
        };

    }
}
