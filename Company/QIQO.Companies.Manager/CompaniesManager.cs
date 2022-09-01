using Dapr.Client;
using Microsoft.Extensions.Logging;
using QIQO.Business.Core.Contracts;
using QIQO.Companies.Data;
using QIQO.Companies.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private readonly DaprClient _daprClient;

        //private readonly IMQPublisher _mqPublisher;

        public CompaniesManager(ILogger<CompaniesManager> logger, DaprClient daprClient, 
            ICompanyRepository companyRepository, ICompanyEntityService companyEntityService)
        {
            _log = logger;
            _daprClient = daprClient;
            //_mqPublisher = mqPublisher;
            _companyRepository = companyRepository;
            _companyEntityService = companyEntityService;
        }
        public Task DeleteCompanyAsync(int companyKey)
        {
            return Task.Run(() => _companyRepository.DeleteByID(companyKey));
        }

        public Task<Company> GetCompanyAsync(string companyCode)
        {
            return Task.Run(() => {
                return new Company(_companyRepository.GetByCode(companyCode, string.Empty));
            });
        }

        public Task<List<Company>> GetCompaniesAsync()
        {
            return Task.Run(() => {
                return _companyEntityService.Map(_companyRepository.GetAll());
            });
        }

        public Task SaveCompanyAsync(Company company)
        {
            return Task.Run(() => {
                _companyRepository.Save(_companyEntityService.Map(company));
                _daprClient.PublishEventAsync("qiqo-pubsub", "qiqo-company-save", company);
            });
        }
    }
}
