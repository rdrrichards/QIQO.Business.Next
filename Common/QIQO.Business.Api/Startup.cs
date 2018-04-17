using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QIQO.Accounts.Data;
using QIQO.Accounts.Manager;
using QIQO.Companies.Data;
using QIQO.Companies.Manager;
using QIQO.Invoices.Manager;
using QIQO.MQ;
using QIQO.Orders.Manager;
using QIQO.Products.Manager;
using Swashbuckle.AspNetCore.Swagger;

namespace QIQO.Business.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "QIQO Business API", Version = "v1" });
            });

            services.AddScoped<IAccountDbContext, AccountDbContext>();
            services.AddScoped<ICompanyDbContext, CompanyDbContext>();

            services.AddTransient<IAccountsManager, AccountsManager>();
            services.AddTransient<ICompaniesManager, CompaniesManager>();
            services.AddTransient<IOrdersManager, OrdersManager>();
            services.AddTransient<IInvoicesManager, InvoicesManager>();
            services.AddTransient<IProductsManager, ProductsManager>();

            services.AddTransient<IMQPublisher, MQPublisher>();
            // services.AddTransient<IMQConsumer, MQConsumer>();

            services.AddSingleton<IHostedService, AccountAuditConsumerService>();
            services.AddSingleton<IHostedService, AccountAddConsumerService>();
            services.AddSingleton<IHostedService, AccountUpdateConsumerService>();
            services.AddSingleton<IHostedService, AccountDeleteConsumerService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QIQO Business API V1");
            });

            app.UseMvc();
        }
    }
}
