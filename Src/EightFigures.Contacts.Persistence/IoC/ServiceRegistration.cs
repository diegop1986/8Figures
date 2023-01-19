using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EightFigures.Contacts.Service.Repository;
using EightFigures.Contacts.Persistence.Repository;
using EightFigures.Contacts.Domain.CustomException.Server;

namespace EightFigures.Contacts.Persistence.IoC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IContactsDbContext, ContactsDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ContactsDB"))
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }

        public static async Task EnsureCreatedAsync(this IApplicationBuilder appServices)
        {
            var serviceScopeFactory = appServices.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IContactsDbContext>();
                if (dbContext is null) throw new ContextNotInstantiatedException();
                await dbContext.Database.EnsureCreatedAsync();
            }
        }
    }
}
