using Data;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using API_Sukha.IServices;
using API_Sukha.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ISecurityServices, SecurityServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IRolServices, RolServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ICustomerTypeServices, CustomerTypeServices>();

builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<ISecurityLogic, SecurityLogic>();
builder.Services.AddScoped<IPersonLogic, PersonLogic>();
builder.Services.AddScoped<IRolLogic, RolLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<ICustomerTypeLogic, CustomerTypeLogic>();

builder.Services.AddDbContext<ServiceContext>(
        options => options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

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