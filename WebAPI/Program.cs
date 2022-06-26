using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RentendContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Password.RequireNonAlphanumeric = false)
	.AddEntityFrameworkStores<RentendContext>();
// Add services to the container.
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPinRepository, PinRepository>();
builder.Services.AddScoped<IPinService, PinService>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddSingleton(AutoMapperConfig.Initialize());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
