using Microsoft.Extensions.Configuration;
using MsStore.Api.Database;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsStore.Api.Contract.Interface;
using MsStore.Api.Contract.Repository;
using MsStore.Identity;
using MsStore.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//user: sa
//password: 123456

//PostgreSql
/* services.AddEntityFrameworkNpgsql().AddDbContext<CleanContext>(opt =>
     opt.UseNpgsql(configurationManager.GetConnectionString("CleanPostgresDB")));*/

//Sql Server
builder.Services.AddDbContext<SQLContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SQLConnection")
    ));
builder.Services.AddControllers().AddJsonOptions(op => op.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketProductRepository, BasketProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IProductPropRepository, ProductPropRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();


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
