using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace QIQO.Invoices.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            Action<DataAccessOptions> configuration = null)
        {
            services.AddTransient<InvoiceDbContext>(serviceProvider => {
                var optionsProvider = serviceProvider.GetService<IOptions<DataAccessOptions>>();
                var options = optionsProvider.Value;

                // Allow the developer to perform further configuration
                configuration?.Invoke(options);

                if (string.IsNullOrEmpty(options.ConnectionString))
                {
                    throw new InvalidOperationException($"No {nameof(DataAccessOptions.ConnectionString)} " +
                        $"was set on the {nameof(DataAccessOptions)}.");
                }
                return new InvoiceDbContext(options.ConnectionString);
            });
            services.AddTransient<IAccountMap, AccountMap>()
                .AddTransient<IAddressMap, AddressMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<IInvoiceMap, InvoiceMap>()
                .AddTransient<IInvoiceItemMap, InvoiceItemMap>()
                .AddTransient<IInvoiceStatusMap, InvoiceStatusMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>()
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<IInvoiceRepository, InvoiceRepository>()
                .AddTransient<IInvoiceItemRepository, InvoiceItemRepository>()
                .AddTransient<IInvoiceStatusRepository, InvoiceStatusRepository>()
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
