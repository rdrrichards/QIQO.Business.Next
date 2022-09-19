using QIQO.Products.Manager;

namespace QIQO.Business.Api
{

    public static class ProductIoC
    {
        public static IServiceCollection AddProductAll(this IServiceCollection services)
        {
            return  services.AddProductManagers()
                .AddProductEntityServices();
        }
        public static IServiceCollection AddProductManagers(this IServiceCollection services)
        {
            return services.AddTransient<IProductsManager, ProductsManager>();
        }
        public static IServiceCollection AddProductEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<IProductEntityService, ProductEntityService>();
        }
    }
}
