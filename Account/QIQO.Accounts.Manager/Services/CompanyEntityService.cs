using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class CompanyEntityService : ICompanyEntityService
    {
        public Company Map(CompanyData comp_data)
        {
            Company company = new Company()
            {
                //CompanyKey = comp_data.CompanyKey,
                //CompanyCode = comp_data.CompanyCode,
                //CompanyName = comp_data.CompanyName,
                //CompanyDesc = comp_data.CompanyDesc,
                //AddedUserID = comp_data.AuditAddUserId,
                //AddedDateTime = comp_data.AuditAddDatetime,
                //UpdateUserID = comp_data.AuditUpdateUserId,
                //UpdateDateTime = comp_data.AuditUpdateDatetime
            };
            return company;
        }

        public CompanyData Map(Company company)
        {
            CompanyData comp_data = new CompanyData()
            {
                CompanyKey = company.CompanyKey,
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                CompanyDesc = company.CompanyDesc
            };
            return comp_data;
        }

    }
}
