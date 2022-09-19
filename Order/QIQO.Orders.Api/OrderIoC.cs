using QIQO.Orders.Manager;

namespace QIQO.Business.Api
{
    public static class OrderIoC
    {
        public static IServiceCollection AddOrderAll(this IServiceCollection services)
        {
            return services.AddOrderManagers()
                .AddOrderEntityService();
        }
        public static IServiceCollection AddOrderManagers(this IServiceCollection services)
        {
            return services.AddTransient<IOrdersManager, OrdersManager>();
        }
        public static IServiceCollection AddOrderEntityService(this IServiceCollection services)
        {
            return services.AddTransient<IOrderEntityService, OrderEntityService>()
                .AddTransient<IOrderItemEntityService, OrderItemEntityService>();
        }
    }
}
