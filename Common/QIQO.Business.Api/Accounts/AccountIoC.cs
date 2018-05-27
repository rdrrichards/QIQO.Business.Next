using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QIQO.Accounts.Manager;
using QIQO.MQ;
using QIQO.Accounts.Data;

namespace QIQO.Business.Api
{
    public static class AccountIoCExtensions
    {
        public static IServiceCollection AddAccountAll(this IServiceCollection services)
        {
            return services.AddAccountDbContexts()
                .AddAccountManagers()
                .AddAccountMQServices()
                .AddAccountMappers()
                .AddAccountRepos()
                .AddAccountEntityServices();
        }
        public static IServiceCollection AddAccountDbContexts(this IServiceCollection services)
        {
            return services.AddScoped<IAccountDbContext, AccountDbContext>();
        }
        public static IServiceCollection AddAccountManagers(this IServiceCollection services)
        {
            return services.AddTransient<IAccountsManager, AccountsManager>();
        }
        public static IServiceCollection AddAccountMQServices(this IServiceCollection services)
        {
            return services.AddTransient<IMQPublisher, MQPublisher>()
                .AddSingleton<IHostedService, AccountCompanyAddConsumerService>()
                .AddSingleton<IHostedService, AccountCompanyUpdateConsumerService>()
                .AddSingleton<IHostedService, AccountCompanyDeleteConsumerService>()
                .AddSingleton<IHostedService, AccountProductAddConsumerService>()
                .AddSingleton<IHostedService, AccountProductUpdateConsumerService>()
                .AddSingleton<IHostedService, AccountProductDeleteConsumerService>();
        }
        public static IServiceCollection AddAccountMappers(this IServiceCollection services)
        {
            return services.AddTransient<IAccountMap, AccountMap>()
                .AddTransient<IAddressMap, AddressMap>()
                .AddTransient<IAttributeMap, AttributeMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<ICompanyMap, CompanyMap>()
                .AddTransient<IContactMap, ContactMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>();
        }
        public static IServiceCollection AddAccountRepos(this IServiceCollection services)
        {
            return services.AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<IAttributeRepository, AttributeRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ICompanyRepository, CompanyRepository>()
                .AddTransient<IContactRepository, ContactRepository>()
                .AddTransient<IFeeScheduleRepository, FeeScheduleRepository>()
                .AddTransient<IPersonRepository, PersonRepository>();
        }
        public static IServiceCollection AddAccountEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<IAccountEntityService, AccountEntityService>();
            //services.AddSingleton<IAddressEntityService, AddressEntityService>();
            //services.AddSingleton<IAttributeEntityService, AttributeEntityService>();
            //services.AddSingleton<ICommentEntityService, CommentEntityService>();
            //services.AddSingleton<ICompanyEntityService, CompanyEntityService>();
            //services.AddSingleton<IContactEntityService, ContactEntityService>();
            //services.AddSingleton<IFeeScheduleEntityService, FeeScheduleEntityService>();
        }
    }
}
