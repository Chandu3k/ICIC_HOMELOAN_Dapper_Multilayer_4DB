using BussinessEntites.Interfaces;
using DBConnectivity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repository;
using Service;
using Service.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region  Sql Dependency Injection
builder.Services.TryAddSingleton<IConnectionFactory,ConnectionFactory>();
#endregion



#region  Dependency Injection for Services and Repositories
builder.Services.AddScoped<IHotelsServices, HotelsService>();
builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMidlandRepository, MidlandRepository>();
builder.Services.AddScoped<IMidlandService, MidlandService>();
#endregion


#region Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
