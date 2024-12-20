using EcommerceAPI.Dtos;
using EcommerceAPI.Infra;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EcommerceAPI.Helpers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    )
);
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<UserProfile>();
});

config.AssertConfigurationIsValid();

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    )
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser, UserServices>();

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
