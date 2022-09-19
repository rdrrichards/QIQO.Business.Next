using QIQO.Accounts.Manager;

namespace QIQO.Business.Api
{
    public static class AccountIoCExtensions
    {
        public static IServiceCollection AddAccountAll(this IServiceCollection services)
        {
            return services.AddAccountManagers()
                .AddAccountEntityServices();
        }
        public static IServiceCollection AddAccountManagers(this IServiceCollection services)
        {
            return services.AddTransient<IAccountsManager, AccountsManager>();
        }
        public static IServiceCollection AddAccountEntityServices(this IServiceCollection services)
        {
            return services.AddTransient<IAccountEntityService, AccountEntityService>();
            //services.AddSingleton<IAddressEntityService, AddressEntityService>();
            //services.AddSingleton<IAttributeEntityService, AttributeEntityService>();
            //services.AddSingleton<ICommentEntityService, CommentEntityService>();
            //services.AddSingleton<ICompanyEntityService, CompanyEntityService>();
            //services.AddSingleton<IContactEntityService, ContactEntityService>();
            //services.AddSingleton<IFeeScheduleEntityService, FeeScheduleEntityService>();
        }
    }
}
