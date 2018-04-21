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
            RegisterMappers(services);
            RegisterRepos(services);
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

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            //services.AddTransient<IHostedService, AccountAddConsumerService>();
            //services.AddTransient<IHostedService, AccountUpdateConsumerService>();
            //services.AddTransient<IHostedService, AccountDeleteConsumerService>();
        }
        internal static void RegisterMappers(IServiceCollection services)
        {
            services.AddTransient<IAddressMap, AddressMap>();
            services.AddTransient<IAttributeMap, AttributeMap>();
            services.AddTransient<ICommentMap, CommentMap>();
            services.AddTransient<ICompanyMap, CompanyMap>();
            services.AddTransient<IContactMap, ContactMap>();
            services.AddTransient<IFeeScheduleMap, FeeScheduleMap>();
            services.AddTransient<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}
