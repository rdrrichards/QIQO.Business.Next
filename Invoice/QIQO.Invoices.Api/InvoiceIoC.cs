using QIQO.Invoices.Manager;

namespace QIQO.Business.Api
{
    public static class InvoiceIoC
    {
        public static IServiceCollection AddInvoiceAll(this IServiceCollection services)
        {
            return services.AddInvoiceManagers()
                .AddInvoiceEntityServices();
        }
        public static IServiceCollection AddInvoiceManagers(this IServiceCollection services)
        {
            return services.AddTransient<IInvoicesManager, InvoicesManager>();
        }
        public static IServiceCollection AddInvoiceEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<IInvoiceEntityService, InvoiceEntityService>();
        }
    }
}
