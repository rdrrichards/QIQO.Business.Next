using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton<IInvoiceMap, InvoiceMap>();
            services.AddSingleton<IInvoiceItemMap, InvoiceItemMap>();
            services.AddSingleton<IInvoiceStatusMap, InvoiceStatusMap>();
            services.AddSingleton<IFeeScheduleMap, FeeScheduleMap>();
            services.AddSingleton<IPersonMap, PersonMap>();
        }
        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
            services.AddSingleton<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddSingleton<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddSingleton<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
