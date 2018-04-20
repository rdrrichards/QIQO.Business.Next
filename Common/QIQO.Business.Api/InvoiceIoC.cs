using Microsoft.Extensions.DependencyInjection;
using QIQO.Invoices.Manager;
using InvoiceData = QIQO.Invoices.Data;

namespace QIQO.Business.Api
{
    public static class InvoiceIoC
    {
        internal static void RegisterAll(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterManagers(services);
            RegisterMQServices(services);
        }
        internal static void RegisterDbContexts(IServiceCollection services)
        {
            services.AddScoped<InvoiceData.IInvoiceDbContext, InvoiceData.InvoiceDbContext>();
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
    }
}
