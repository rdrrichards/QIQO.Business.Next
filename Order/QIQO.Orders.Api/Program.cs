using QIQO.Business.Api;
using QIQO.Orders.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddOrderAll();
builder.Services.AddDataAccessServices(options =>
{
    options.ConnectionString = builder.Configuration["ConnectionStrings:OrderManagement"];
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
