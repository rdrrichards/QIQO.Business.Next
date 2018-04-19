using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QIQO.Accounts.Manager;
using QIQO.Companies.Manager;
using QIQO.Invoices.Manager;
using QIQO.MQ;
using QIQO.Orders.Manager;
using QIQO.Products.Manager;

using AccountData = QIQO.Accounts.Data;
using CompanyData = QIQO.Companies.Data;
using InvoiceData = QIQO.Invoices.Data;
using OrderData = QIQO.Orders.Data;
using ProductData = QIQO.Products.Data;

namespace QIQO.Business.Api
{
    public static class IoC
    {
        internal static void RegisterAll(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterManagers(services);
            RegisterMQServices(services);
        }
        internal static void RegisterDbContexts(IServiceCollection services)
        { 
            services.AddScoped<AccountData.IAccountDbContext, AccountData.AccountDbContext>();
            services.AddScoped<CompanyData.ICompanyDbContext, CompanyData.CompanyDbContext>();
            services.AddScoped<InvoiceData.IInvoiceDbContext, InvoiceData.InvoiceDbContext>();
            services.AddScoped<OrderData.IOrderDbContext, OrderData.OrderDbContext>();
            services.AddScoped<ProductData.IProductDbContext, ProductData.ProductDbContext>();
        }
        internal static void RegisterManagers(IServiceCollection services)
        {
            services.AddTransient<IAccountsManager, AccountsManager>();
            services.AddTransient<ICompaniesManager, CompaniesManager>();
            services.AddTransient<IOrdersManager, OrdersManager>();
            services.AddTransient<IInvoicesManager, InvoicesManager>();
            services.AddTransient<IProductsManager, ProductsManager>();
        }
        internal static void RegisterMQServices(IServiceCollection services)
        {
            services.AddTransient<IMQPublisher, MQPublisher>();
            // services.AddTransient<IMQConsumer, MQConsumer>();

            services.AddSingleton<IHostedService, AccountAuditConsumerService>();
            services.AddSingleton<IHostedService, AccountAddConsumerService>();
            services.AddSingleton<IHostedService, AccountUpdateConsumerService>();
            services.AddSingleton<IHostedService, AccountDeleteConsumerService>();
        }
    }
}
