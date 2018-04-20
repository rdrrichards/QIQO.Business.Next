using Microsoft.Extensions.DependencyInjection;
using QIQO.Companies.Manager;
using QIQO.Companies.Data;

namespace QIQO.Business.Api
{
    public static class CompanyIoC
    {
        internal static void RegisterAll(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterManagers(services);
            RegisterMQServices(services);
        }
        internal static void RegisterDbContexts(IServiceCollection services)
        {
            services.AddScoped<ICompanyDbContext, CompanyDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<ICompaniesManager, CompaniesManager>();
        }
        internal static void RegisterMQServices(IServiceCollection services)
        {
            //services.AddTransient<IMQPublisher, MQPublisher>();

            //services.AddSingleton<IHostedService, AccountAuditConsumerService>();
            //services.AddSingleton<IHostedService, AccountAddConsumerService>();
            //services.AddSingleton<IHostedService, AccountUpdateConsumerService>();
            //services.AddSingleton<IHostedService, AccountDeleteConsumerService>();
        }
    }
}
