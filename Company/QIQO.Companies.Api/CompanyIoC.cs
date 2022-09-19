using QIQO.Companies.Manager;

namespace QIQO.Business.Api
{
    public static class CompanyIoC
    {
        public static IServiceCollection AddCompanyAll(this IServiceCollection services)
        {
            return services.AddCompanyManagers()
                .AddCompanyEntityServices();
        }
        public static IServiceCollection AddCompanyManagers(this IServiceCollection services)
        {
            return services.AddTransient<ICompaniesManager, CompaniesManager>();
        }
        public static IServiceCollection AddCompanyEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<ICompanyEntityService, CompanyEntityService>();
        }
    }
}
