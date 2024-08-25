using DefaultCorsPolicyNugetPackage;
using eHospitalServer.Business;
using eHospitalServer.DataAccess;
using eHospitalServer.WebAPI.Middlewares;
using Microsoft.AspNetCore.Identity;
using Scrutor;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(configure =>
{
    configure.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader() 
            .AllowAnyOrigin() 
            .AllowAnyMethod(); 
    });
});


builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

        
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();
ExtensionsMiddleware.CreateFirstUsers(app);

app.UseHttpsRedirection();

app.MapControllers()
    .RequireAuthorization(policy =>
    {
        policy.RequireClaim(ClaimTypes.NameIdentifier);
        policy.AddAuthenticationSchemes("Bearer");
    });

app.Run();
