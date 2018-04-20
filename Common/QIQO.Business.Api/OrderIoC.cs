using Microsoft.Extensions.DependencyInjection;
using QIQO.Orders.Manager;
using OrderData = QIQO.Orders.Data;

namespace QIQO.Business.Api
{
    public static class OrderIoC
    {
        internal static void RegisterAll(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterManagers(services);
            RegisterMQServices(services);
        }
        internal static void RegisterDbContexts(IServiceCollection services)
        {
            services.AddScoped<OrderData.IOrderDbContext, OrderData.OrderDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<IOrdersManager, OrdersManager>();
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
