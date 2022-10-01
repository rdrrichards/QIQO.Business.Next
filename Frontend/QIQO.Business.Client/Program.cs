using NWebsec.AspNetCore.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3601";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "60001";

builder.Services.AddDaprClient(builder => builder
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddDapr();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHsts(options => options.MaxAge(days: 365)
    .IncludeSubdomains());
app.UseXContentTypeOptions();
app.UseXXssProtection(options => options.EnabledWithBlockMode());
app.UseXfo(options => options.SameOrigin());
app.UseReferrerPolicy(opts => opts.NoReferrer());
app.UseCsp(options => options.DefaultSources(s => s.Self())
    .StyleSources(s => s.Self()
    .UnsafeInline()
).ScriptSources(s => s.Self()
    .UnsafeInline()
    .UnsafeEval())
);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
