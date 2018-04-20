using Microsoft.Extensions.DependencyInjection;
using QIQO.Products.Manager;
using QIQO.Products.Data;

namespace QIQO.Business.Api
{

    public static class ProductIoC
    {
        internal static void RegisterAll(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterManagers(services);
            RegisterMQServices(services);
        }
        internal static void RegisterDbContexts(IServiceCollection services)
        {
            services.AddScoped<IProductDbContext, ProductDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<IProductsManager, ProductsManager>();
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
