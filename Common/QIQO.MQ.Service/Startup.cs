using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QIQO.MQ.Service.Consumers;

namespace QIQO.MQ.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            services.AddTransient<IConsumer, Consumer>();
            services.AddSingleton<IAccountConsumer>(new AccountConsumer(Configuration, services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            applicationLifetime.ApplicationStopping.Register(OnShutdown);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(Configuration["QueueConfig:Account:RecieveAuditQueueName"]);
            });
        }

        private void OnShutdown()
        {
            var svs = Services.BuildServiceProvider();
            svs.GetService<IAccountConsumer>().StopRecieving();
            // accountConsumer.StopRecieving();
        }
    }
}
