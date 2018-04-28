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

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            //services.AddTransient<IHostedService, AccountAddConsumerService>();
            //services.AddTransient<IHostedService, AccountUpdateConsumerService>();
            //services.AddTransient<IHostedService, AccountDeleteConsumerService>();
        }
        internal static void RegisterMappers(IServiceCollection services)
        {
            services.AddTransient<IAccountMap, AccountMap>();
            services.AddTransient<IAddressMap, AddressMap>();
            services.AddTransient<ICommentMap, CommentMap>();
            services.AddTransient<IOrderHeaderMap, OrderHeaderMap>();
            services.AddTransient<IOrderItemMap, OrderItemMap>();
            services.AddTransient<IOrderStatusMap, OrderStatusMap>();
            services.AddTransient<IFeeScheduleMap, FeeScheduleMap>();
            services.AddTransient<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IOrderHeaderRepository, OrderHeaderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
            services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}