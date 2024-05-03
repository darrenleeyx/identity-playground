using IdentityPlayground;
using IdentityPlayground.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthorization();
services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.Run();