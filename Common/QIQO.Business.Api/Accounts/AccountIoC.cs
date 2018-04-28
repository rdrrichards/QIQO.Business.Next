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
            RegisterEntityServices(services);
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

            //services.AddSingleton<IHostedService, AccountAuditConsumerService>();
            //services.AddSingleton<IHostedService, AccountAddConsumerService>();
            //services.AddSingleton<IHostedService, AccountUpdateConsumerService>();
            //services.AddSingleton<IHostedService, AccountDeleteConsumerService>();

            services.AddSingleton<IHostedService, AccountCompanyAddConsumerService>();
            services.AddSingleton<IHostedService, AccountCompanyUpdateConsumerService>();
            services.AddSingleton<IHostedService, AccountCompanyDeleteConsumerService>();

            services.AddSingleton<IHostedService, AccountProductAddConsumerService>();
            services.AddSingleton<IHostedService, AccountProductUpdateConsumerService>();
            services.AddSingleton<IHostedService, AccountProductDeleteConsumerService>();
        }
        internal static void RegisterMappers(IServiceCollection services)
        {
            services.AddTransient<IAccountMap, AccountMap>();
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
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
        internal static void RegisterEntityServices(IServiceCollection services)
        {
            services.AddTransient<IAccountEntityService, AccountEntityService>();
            //services.AddSingleton<IAddressEntityService, AddressEntityService>();
            //services.AddSingleton<IAttributeEntityService, AttributeEntityService>();
            //services.AddSingleton<ICommentEntityService, CommentEntityService>();
            //services.AddSingleton<ICompanyEntityService, CompanyEntityService>();
            //services.AddSingleton<IContactEntityService, ContactEntityService>();
            //services.AddSingleton<IFeeScheduleEntityService, FeeScheduleEntityService>();
        }
    }
}
