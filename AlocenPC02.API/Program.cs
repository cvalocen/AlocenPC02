using AlocenPC02.DOMAIN.Core.Interfaces;
using AlocenPC02.DOMAIN.Infrastructure.Data;
using AlocenPC02.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//==

//Get ConnectionString
var connectionString = builder
    .Configuration
    .GetConnectionString("DevConnection");

//Add dbContext
builder
    .Services
    .AddDbContext<SalesContext>
    (options => options.UseSqlServer(connectionString));

//registro de la interfaz

builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();

//==

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
