using Microsoft.Extensions.Logging;
using QIQO.Accounts.Manager;
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
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyAsync(string companyCode);
        Task DeleteCompanyAsync(int companyKey);
        Task UpdateCompanyAsync(Company company);
    }
    public class CompaniesManager : ICompaniesManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyEntityService _companyEntityService;
        private readonly ILogger<CompaniesManager> _log;
        private readonly IMQPublisher _mqPublisher;

        public CompaniesManager(ILogger<CompaniesManager> logger, IMQPublisher mqPublisher,
            ICompanyRepository companyRepository, ICompanyEntityService companyEntityService)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _companyRepository = companyRepository;
            _companyEntityService = companyEntityService;
        }
        public Task DeleteCompanyAsync(int companyKey)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyAsync(string companyCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetCompaniesAsync()
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
