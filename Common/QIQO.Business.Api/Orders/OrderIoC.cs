using Microsoft.Extensions.DependencyInjection;
using QIQO.Orders.Manager;
using QIQO.Orders.Data;
using Microsoft.Extensions.Hosting;

namespace QIQO.Business.Api
{
    public static class OrderIoC
    {
        public static IServiceCollection AddOrderAll(this IServiceCollection services)
        {
            return services.AddOrderDbContexts()
                .AddOrderManagers()
                .AddOrderMQServices()
                .AddOrderMappers()
                .AddOrderRepos();
        }
        public static IServiceCollection AddOrderDbContexts(this IServiceCollection services)
        {
            return services.AddScoped<IOrderDbContext, OrderDbContext>();
        }
        public static IServiceCollection AddOrderManagers(this IServiceCollection services)
        {
            return services.AddTransient<IOrdersManager, OrdersManager>();
        }
        public static IServiceCollection AddOrderMQServices(this IServiceCollection services)
        {
            //services.AddTransient<IMQPublisher, MQPublisher>();

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            return services.AddTransient<IHostedService, OrderAccountAddConsumerService>()
                .AddTransient<IHostedService, OrderAccountUpdateConsumerService>()
                .AddTransient<IHostedService, OrderAccountDeleteConsumerService>()
                .AddTransient<IHostedService, OrderCompanyAddConsumerService>()
                .AddTransient<IHostedService, OrderCompanyUpdateConsumerService>()
                .AddTransient<IHostedService, OrderCompanyDeleteConsumerService>()
                .AddTransient<IHostedService, OrderProductAddConsumerService>()
                .AddTransient<IHostedService, OrderProductUpdateConsumerService>()
                .AddTransient<IHostedService, OrderProductDeleteConsumerService>();
        }
        public static IServiceCollection AddOrderMappers(this IServiceCollection services)
        {
            return services.AddTransient<IAccountMap, AccountMap>()
                .AddTransient<IAddressMap, AddressMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<IOrderHeaderMap, OrderHeaderMap>()
                .AddTransient<IOrderItemMap, OrderItemMap>()
                .AddTransient<IOrderStatusMap, OrderStatusMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>();
        }
        public static IServiceCollection AddOrderRepos(this IServiceCollection services)
        {
            return services.AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IOrderHeaderRepository, OrderHeaderRepository>()
                .AddTransient<IOrderItemRepository, OrderItemRepository>()
                .AddTransient<IOrderStatusRepository, OrderStatusRepository>()
                .AddTransient<IFeeScheduleRepository, FeeScheduleRepository>()
                .AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}
