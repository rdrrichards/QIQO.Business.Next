using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace QIQO.Accounts.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            Action<DataAccessOptions> configuration = null)
        {
            services.AddTransient<AccountDbContext>(serviceProvider => {
                var optionsProvider = serviceProvider.GetService<IOptions<DataAccessOptions>>();
                var options = optionsProvider.Value;

                // Allow the developer to perform further configuration
                configuration?.Invoke(options);

                if (string.IsNullOrEmpty(options.ConnectionString))
                {
                    throw new InvalidOperationException($"No {nameof(DataAccessOptions.ConnectionString)} " +
                        $"was set on the {nameof(DataAccessOptions)}.");
                }
                return new AccountDbContext(options.ConnectionString);
            });
            services.AddTransient<IAddressMap, AddressMap>()
                .AddTransient<IAttributeMap, AttributeMap>()
                .AddTransient<ICommentMap, CommentMap>()
                .AddTransient<ICompanyMap, CompanyMap>()
                .AddTransient<IContactMap, ContactMap>()
                .AddTransient<IFeeScheduleMap, FeeScheduleMap>()
                .AddTransient<IPersonMap, PersonMap>()
                .AddTransient<IAddressRepository, AddressRepository>()
                .AddTransient<IAttributeRepository, AttributeRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ICompanyRepository, CompanyRepository>()
                .AddTransient<IContactRepository, ContactRepository>()
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
