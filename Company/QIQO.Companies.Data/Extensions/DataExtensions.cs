using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace QIQO.Companies.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            Action<DataAccessOptions> configuration = null)
        {
            services.AddTransient<CompanyDbContext>(serviceProvider => {
                var optionsProvider = serviceProvider.GetService<IOptions<DataAccessOptions>>();
                var options = optionsProvider.Value;

                // Allow the developer to perform further configuration
                configuration?.Invoke(options);

                if (string.IsNullOrEmpty(options.ConnectionString))
                {
                    throw new InvalidOperationException($"No {nameof(DataAccessOptions.ConnectionString)} " +
                        $"was set on the {nameof(DataAccessOptions)}.");
                }
                return new CompanyDbContext(options.ConnectionString);
            });
            services.AddTransient<IAddressMap, AddressMap>()
                .AddTransient<IAttributeMap, AttributeMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<ICompanyMap, CompanyMap>()
                .AddTransient<IContactMap, ContactMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>();

            return services;
        }
        public static void AddDataServices(this IServiceCollection services,
           Action<DataAccessOptions> configuration = null)
        {
            AddDataAccessServices(services, configuration);
        }
    }
}
