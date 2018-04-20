﻿using Microsoft.Extensions.DependencyInjection;
using QIQO.Orders.Manager;
using QIQO.Orders.Data;

namespace QIQO.Business.Api
{
    public static class OrderIoC
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
            services.AddScoped<IOrderDbContext, OrderDbContext>();
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
        internal static void RegisterMappers(IServiceCollection services)
        {
            services.AddSingleton<IAccountMap, AccountMap>();
            services.AddSingleton<IAddressMap, AddressMap>();
            services.AddSingleton<ICommentMap, CommentMap>();
            services.AddSingleton<IOrderHeaderMap, OrderHeaderMap>();
            services.AddSingleton<IOrderItemMap, OrderItemMap>();
            services.AddSingleton<IOrderStatusMap, OrderStatusMap>();
            services.AddSingleton<IFeeScheduleMap, FeeScheduleMap>();
            services.AddSingleton<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IOrderHeaderRepository, OrderHeaderRepository>();
            services.AddSingleton<IOrderItemRepository, OrderItemRepository>();
            services.AddSingleton<IOrderStatusRepository, OrderStatusRepository>();
            services.AddSingleton<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
