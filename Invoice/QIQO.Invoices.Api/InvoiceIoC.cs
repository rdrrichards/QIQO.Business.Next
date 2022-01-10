using Microsoft.Extensions.DependencyInjection;
using QIQO.Invoices.Manager;
using QIQO.Invoices.Data;
using Microsoft.Extensions.Hosting;

namespace QIQO.Business.Api
{
    public static class InvoiceIoC
    {
        public static IServiceCollection AddInvoiceAll(this IServiceCollection services)
        {
            return services.AddInvoiceDbContexts()
                .AddInvoiceManagers()
                .AddInvoiceMQServices()
                .AddInvoiceMappers()
                .AddInvoiceRepos()
                .AddInvoiceEntityServices();
        }
        public static IServiceCollection AddInvoiceDbContexts(this IServiceCollection services)
        {
            return services.AddScoped<IInvoiceDbContext, InvoiceDbContext>();
        }
        public static IServiceCollection AddInvoiceManagers(this IServiceCollection services)
        {
            return services.AddTransient<IInvoicesManager, InvoicesManager>();
        }
        public static IServiceCollection AddInvoiceMQServices(this IServiceCollection services)
        {
            //services.AddTransient<IMQPublisher, MQPublisher>();

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            return services; //.AddTransient<IHostedService, InvoiceAccountAddConsumerService>()
                //.AddTransient<IHostedService, InvoiceAccountUpdateConsumerService>()
                //.AddTransient<IHostedService, InvoiceAccountDeleteConsumerService>()
                //.AddTransient<IHostedService, InvoiceCompanyAddConsumerService>()
                //.AddTransient<IHostedService, InvoiceCompanyUpdateConsumerService>()
                //.AddTransient<IHostedService, InvoiceCompanyDeleteConsumerService>()
                //.AddTransient<IHostedService, InvoiceProductAddConsumerService>()
                //.AddTransient<IHostedService, InvoiceProductUpdateConsumerService>()
                //.AddTransient<IHostedService, InvoiceProductDeleteConsumerService>();
        }
        public static IServiceCollection AddInvoiceMappers(this IServiceCollection services)
        {
            return services.AddTransient<IAccountMap, AccountMap>()
                .AddTransient<IAddressMap, AddressMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<IInvoiceMap, InvoiceMap>()
                .AddTransient<IInvoiceItemMap, InvoiceItemMap>()
                .AddTransient<IInvoiceStatusMap, InvoiceStatusMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>();
        }
        public static IServiceCollection AddInvoiceRepos(this IServiceCollection services)
        {
            return services.AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IInvoiceRepository, InvoiceRepository>()
                .AddTransient<IInvoiceItemRepository, InvoiceItemRepository>()
                .AddTransient<IInvoiceStatusRepository, InvoiceStatusRepository>()
                .AddTransient<IFeeScheduleRepository, FeeScheduleRepository>()
                .AddTransient<IPersonRepository, PersonRepository>();
        }
        public static IServiceCollection AddInvoiceEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<IInvoiceEntityService, InvoiceEntityService>();
        }
    }
}
