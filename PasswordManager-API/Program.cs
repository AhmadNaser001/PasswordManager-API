using Microsoft.EntityFrameworkCore;
using PasswordManager_API.Context;
using PasswordManager_API.Controllers;
using PasswordManager_API.Interfaces;
using PasswordManager_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PasswordManagerDbContext>(opt => opt.UseSqlServer("Data Source=USER\\SQLEXPRESS;Initial Catalog=PasswordManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

builder.Services.AddScoped<ILookupInterface, LookupAppService>();
builder.Services.AddScoped<IUserAuthanticationInterface, AuthanticationAppSevice>();

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
