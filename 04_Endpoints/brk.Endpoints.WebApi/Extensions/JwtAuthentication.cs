using brk.Endpoints.WebApi.Services.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace brk.Endpoints.WebApi.Extensions
{
    public static class JwtAuthentication
    {
        public static void AddJwtAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            var setting = configuration.GetSection("ServiceConfiguration:JwtSetting").Get<JwtSetting>();
            if (setting == null)
                throw new ArgumentNullException(nameof(setting), "تنظیمات احراز هویت مقداردهی نشده است");

            services.AddScoped<IJwtManager, JwtManager>();
            services.Configure<JwtSetting>(configuration.GetSection("ServiceConfiguration:JwtSetting"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(setting.Key);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = setting.Issuer,
                    ValidAudience = setting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });
        }

        public static void AddAppSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });
        }
    }
}
