using QIQO.Business.Api;
using QIQO.Invoices.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddInvoiceAll();
builder.Services.AddDataAccessServices(options =>
{
    options.ConnectionString = builder.Configuration["ConnectionStrings:InoiceManagement"];
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer().AddDaprClient();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
