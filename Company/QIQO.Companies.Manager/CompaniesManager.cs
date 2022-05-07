using Microsoft.Extensions.Logging;
using QIQO.Accounts.Manager;
using QIQO.Companies.Data;
using QIQO.Companies.Domain;
using QIQO.MQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;

namespace QIQO.Companies.Manager
{
    public interface ICompaniesManager {

        Task SaveCompanyAsync(Company company);
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyAsync(string companyCode);
        Task DeleteCompanyAsync(int companyKey);
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
            return Task.Factory.StartNew(() => _companyRepository.DeleteByID(companyKey));
        }

        public Task<Company> GetCompanyAsync(string companyCode)
        {
            return Task.Factory.StartNew(() => {
                return new Company(_companyRepository.GetByCode(companyCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task<List<Company>> GetCompaniesAsync()
        {
            return Task.Factory.StartNew(() => {
                return _companyEntityService.Map(_companyRepository.GetAll());
            });
        }

        public Task SaveCompanyAsync(Company company)
        {
            return Task.Factory.StartNew(() => {
                _companyRepository.Save(_companyEntityService.Map(company));
                _mqPublisher.Send(company, "company", "company.add", "company.add");
            });
        }
    }
}
