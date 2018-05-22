using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Api
{
    public class StatsServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStatsService _statsService;

        public StatsServiceMiddleware(RequestDelegate next, IStatsService statsService)
        {
            _next = next;
            _statsService = statsService;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var item = context.Request.Path;
            var measure = new Measure(item, new Occurence(DateTime.Now, context.Request.Body));
            _statsService.AddMeasure(item, measure);
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
    }
}
