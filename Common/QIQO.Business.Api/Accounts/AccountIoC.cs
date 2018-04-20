using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QIQO.Accounts.Manager;
using QIQO.MQ;
using QIQO.Accounts.Data;

namespace QIQO.Business.Api
{
    public static class AccountIoC
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
            services.AddScoped<IAccountDbContext, AccountDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<IAccountsManager, AccountsManager>();
        }
        internal static void RegisterMQServices(IServiceCollection services)
        {
            services.AddTransient<IMQPublisher, MQPublisher>();

            services.AddSingleton<IHostedService, AccountAuditConsumerService>();
            services.AddSingleton<IHostedService, AccountAddConsumerService>();
            services.AddSingleton<IHostedService, AccountUpdateConsumerService>();
            services.AddSingleton<IHostedService, AccountDeleteConsumerService>();
        }
        internal static void RegisterMappers(IServiceCollection services)
        {
            services.AddSingleton<IAccountMap, AccountMap>();
            services.AddSingleton<IAddressMap, AddressMap>();
            services.AddSingleton<IAttributeMap, AttributeMap>();
            services.AddSingleton<ICommentMap, CommentMap>();
            services.AddSingleton<ICompanyMap, CompanyMap>();
            services.AddSingleton<IContactMap, ContactMap>();
            services.AddSingleton<IFeeScheduleMap, FeeScheduleMap>();
            services.AddSingleton<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<IAttributeRepository, AttributeRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IContactRepository, ContactRepository>();
            services.AddSingleton<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
