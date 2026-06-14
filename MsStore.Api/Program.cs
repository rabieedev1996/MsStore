using Microsoft.Extensions.Configuration;
using MsStore.Api.Database;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
