using ASP.NET_Core_Web_API.DAL;
using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWT Token API",
        Version = "v1",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description= "Enter 'Bearer key' space 'JWT Token'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
               {
                   Type=ReferenceType.SecurityScheme,
                   Id="Bearer"
               }
           },
           new string[]{ }
        }
    });
    });

builder.Services.AddSingleton<IRepository<EmployeeModel>, EmployeeRepository>();
var key = "!@#$%^&*()!@#$%^&*()1234567890!@#$%^&*()!@#$%^&*()";
builder.Services.AddSingleton<IJwtService>(new ImplementationIJwtService(key));

//ASP.NET Core middleware that enables an application to receive an OpenID Connect bearer token.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});


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
