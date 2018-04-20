using Microsoft.Extensions.Logging;
using QIQO.Companies.Data;
using QIQO.Companies.Domain;
using QIQO.MQ;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Companies.Manager
{
    public interface ICompaniesManager {

        Task SaveCompanyAsync(Company company);
        Task<List<Company>> GetCompanysAsync();
        Task<Company> GetCompanyAsync(string companyCode);
        Task DeleteCompanyAsync(int companyKey);
        Task UpdateCompanyAsync(Company company);
    }
    public class CompaniesManager : ICompaniesManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompaniesManager> _log;
        private readonly IMQPublisher _mqPublisher;

        public CompaniesManager(ILogger<CompaniesManager> logger, IMQPublisher mqPublisher, ICompanyRepository companyRepository)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _companyRepository = companyRepository;
        }
        public Task DeleteCompanyAsync(int companyKey)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyAsync(string companyCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetCompanysAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
