using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class StatsServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStatsService _statsService;
        private readonly ILogger<StatsServiceMiddleware> _logger;

        public StatsServiceMiddleware(RequestDelegate next, IStatsService statsService, ILogger<StatsServiceMiddleware> logger)
        {
            _next = next;
            _statsService = statsService;
            _logger = logger;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var item = context.Request.Path;
            var ip = context.Request.HttpContext.Connection.RemoteIpAddress;
            _logger.LogInformation($"RemoteIpAddress: {ip}");
            if (!item.Value.Contains("Stat"))
            {
                var measure = new Measure(item, new Occurence(DateTime.Now, context.Request.Method));
                _statsService.AddMeasure(item, measure);
            }
            return _next(context);
        }
    }
    public static class StatsServiceMiddlewareExtensions
    {
        public static IApplicationBuilder UseStatsService(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatsServiceMiddleware>();
        }
        public static IServiceCollection AddStatsService(
            this IServiceCollection services)
        {
            return services.AddSingleton<IStatsService, StatsService>();
        }
    }
}
