using QIQO.Companies.Manager;
using QIQO.Companies.Data;

namespace QIQO.Business.Api
{
    public static class CompanyIoC
    {
        public static IServiceCollection AddCompanyAll(this IServiceCollection services)
        {
            return services.AddCompanyDbContexts()
                .AddCompanyManagers()
                .AddCompanyMQServices()
                .AddCompanyMappers()
                .AddCompanyRepos()
                .AddCompanyEntityServices();
        }
        public static IServiceCollection AddCompanyDbContexts(this IServiceCollection services)
        {
            return services.AddTransient<ICompanyDbContext, CompanyDbContext>();
        }
        public static IServiceCollection AddCompanyManagers(this IServiceCollection services)
        {
            return services.AddTransient<ICompaniesManager, CompaniesManager>();
        }
        public static IServiceCollection AddCompanyMQServices(this IServiceCollection services)
        {
            return services;
            //services.AddTransient<IMQPublisher, MQPublisher>();

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            //services.AddTransient<IHostedService, AccountAddConsumerService>();
            //services.AddTransient<IHostedService, AccountUpdateConsumerService>();
            //services.AddTransient<IHostedService, AccountDeleteConsumerService>();
        }
        public static IServiceCollection AddCompanyMappers(this IServiceCollection services)
        {
            return services.AddTransient<IAddressMap, AddressMap>()
                .AddTransient<IAttributeMap, AttributeMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<ICompanyMap, CompanyMap>()
                .AddTransient<IContactMap, ContactMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>();
        }
        public static IServiceCollection AddCompanyRepos(this IServiceCollection services)
        {
            return services.AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<IAttributeRepository, AttributeRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ICompanyRepository, CompanyRepository>()
                .AddTransient<IContactRepository, ContactRepository>()
                .AddTransient<IFeeScheduleRepository, FeeScheduleRepository>()
                .AddTransient<IPersonRepository, PersonRepository>();
        }
        public static IServiceCollection AddCompanyEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<ICompanyEntityService, CompanyEntityService>();
        }
    }
}
