using IDR = TaskManagerApi.Dal.Repositories;
using IDS = TaskManagerApi.Dal.Services;

using Microsoft.Data.SqlClient;
using System.Data.Common;
using TaskManagerApi.Bll.Repositories;
using TaskManagerApi.Bll.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using TaskManagerApi.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Issuer"],
                ValidAudience = configuration["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("peALmr3S@BuYyKc-^E_enw*KVTFfU8D+7XQaTL2S")),                         
            };
        });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor(); //Donne accès l'injection de IHttpContextAccessor
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("database")));
builder.Services.AddScoped<IDR.IAuthRepository, IDS.AuthService>();
builder.Services.AddScoped<IDR.ITacheRepository, IDS.TacheService>();
builder.Services.AddScoped<IAuthRepository, AuthService>();
builder.Services.AddScoped<ITacheRepository, TacheService>();
builder.Services.AddScoped<ITokenRepository, TokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
