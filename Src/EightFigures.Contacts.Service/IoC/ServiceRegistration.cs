using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EightFigures.Contacts.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using EightFigures.Contacts.Service.Validation;
using EightFigures.Contacts.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EightFigures.Contacts.Service.IoC
{
    public static class ServiceRegistration
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            Configuration = config;
            services.AddSingleton(_ => Configuration);
            services.AddSingleton<ISettings, Settings>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenManagerService, TokenManagerService>();
            services.AddValidatorsFromAssemblyContaining<ContactAddDtoValidation>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            return services;
        }
    }
}
