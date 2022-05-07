using QIQO.Products.Manager;
using QIQO.Products.Data;

namespace QIQO.Business.Api
{

    public static class ProductIoC
    {
        public static IServiceCollection AddProductAll(this IServiceCollection services)
        {
            return  services.AddProductDbContexts()
                .AddProductManagers()
                .AddProductMQServices()
                .AddProductMappers()
                .AddProductRepos();
        }
        public static IServiceCollection AddProductDbContexts(this IServiceCollection services)
        {
            return services.AddScoped<IProductDbContext, ProductDbContext>();
        }
        public static IServiceCollection AddProductManagers(this IServiceCollection services)
        {
            return services.AddTransient<IProductsManager, ProductsManager>();
        }
        public static IServiceCollection AddProductMQServices(this IServiceCollection services)
        {
            return services;
            //services.AddTransient<IMQPublisher, MQPublisher>();

            //services.AddTransient<IHostedService, AccountAuditConsumerService>();
            //services.AddTransient<IHostedService, AccountAddConsumerService>();
            //services.AddTransient<IHostedService, AccountUpdateConsumerService>();
            //services.AddTransient<IHostedService, AccountDeleteConsumerService>();
        }
        public static IServiceCollection AddProductMappers(this IServiceCollection services)
        {
            return services.AddTransient<IProductMap, ProductMap>()
            .AddTransient<IProductTypeMap, ProductTypeMap>();
        }
        public static IServiceCollection AddProductRepos(this IServiceCollection services)
        {
            return services.AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IProductTypeRepository, ProductTypeRepository>();
        }
    }
}
