using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace QIQO.Orders.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            Action<DataAccessOptions> configuration = null)
        {
            services.AddTransient<OrderDbContext>(serviceProvider => {
                var optionsProvider = serviceProvider.GetService<IOptions<DataAccessOptions>>();
                var options = optionsProvider.Value;

                // Allow the developer to perform further configuration
                configuration?.Invoke(options);

                if (string.IsNullOrEmpty(options.ConnectionString))
                {
                    throw new InvalidOperationException($"No {nameof(DataAccessOptions.ConnectionString)} " +
                        $"was set on the {nameof(DataAccessOptions)}.");
                }
                return new OrderDbContext(options.ConnectionString);
            });
            services.AddTransient<IAccountMap, AccountMap>()
                .AddTransient<IAddressMap, AddressMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<IOrderHeaderMap, OrderHeaderMap>()
                .AddTransient<IOrderItemMap, OrderItemMap>()
                .AddTransient<IOrderStatusMap, OrderStatusMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>()
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IOrderHeaderRepository, OrderHeaderRepository>()
                .AddTransient<IOrderItemRepository, OrderItemRepository>()
                .AddTransient<IOrderStatusRepository, OrderStatusRepository>()
                .AddTransient<IFeeScheduleRepository, FeeScheduleRepository>()
                .AddTransient<IPersonRepository, PersonRepository>();

            return services;
        }
        public static void AddDataServices(this IServiceCollection services,
           Action<DataAccessOptions> configuration = null)
        {
            AddDataAccessServices(services, configuration);
        }
    }
}
