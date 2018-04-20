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
    }
}
