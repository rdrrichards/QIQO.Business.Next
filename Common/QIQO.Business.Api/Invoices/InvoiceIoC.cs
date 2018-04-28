﻿using Microsoft.Extensions.DependencyInjection;
using QIQO.Invoices.Manager;
using QIQO.Invoices.Data;

namespace QIQO.Business.Api
{
    public static class InvoiceIoC
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
            services.AddScoped<IInvoiceDbContext, InvoiceDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<IInvoicesManager, InvoicesManager>();
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
            services.AddTransient<IInvoiceMap, InvoiceMap>();
            services.AddTransient<IInvoiceItemMap, InvoiceItemMap>();
            services.AddTransient<IInvoiceStatusMap, InvoiceStatusMap>();
            services.AddTransient<IFeeScheduleMap, FeeScheduleMap>();
            services.AddTransient<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddTransient<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}