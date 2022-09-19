using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace QIQO.Products.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            Action<DataAccessOptions> configuration = null)
        {
            services.AddTransient<IProductDbContext>(serviceProvider => {
                var optionsProvider = serviceProvider.GetService<IOptions<DataAccessOptions>>();
                var options = optionsProvider.Value;

                // Allow the developer to perform further configuration
                configuration?.Invoke(options);

                if (string.IsNullOrEmpty(options.ConnectionString))
                {
                    throw new InvalidOperationException($"No {nameof(DataAccessOptions.ConnectionString)} " +
                        $"was set on the {nameof(DataAccessOptions)}.");
                }
                return new ProductDbContext(options.ConnectionString);
            });
            services.AddTransient<IProductMap, ProductMap>()
                .AddTransient<IProductTypeMap, ProductTypeMap>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductTypeRepository, ProductTypeRepository>();

            return services;
        }
        public static void AddDataServices(this IServiceCollection services,
           Action<DataAccessOptions> configuration = null)
        {
            AddDataAccessServices(services, configuration);
        }
    }
}
