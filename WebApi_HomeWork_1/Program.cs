

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi_HomeWork_1.Business.Abstract;
using WebApi_HomeWork_1.Business.Concrete;
using WebApi_HomeWork_1.DataAccess.Abstraction;
using WebApi_HomeWork_1.DataAccess.Concrete.EFEntityFramework;
using WebApi_HomeWork_1.DataAccess.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dal
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();
builder.Services.AddScoped<IOrderDal, EFOrderDal>();

// Service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ProductDbContext>(option =>
{
    option.UseSqlServer(connectionString);


});


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
