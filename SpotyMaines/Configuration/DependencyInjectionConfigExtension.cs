using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpotyMaines.Domain.Shared;
using SpotyMaines.Infra.ORM.AutenticationModule;
using SpotyMaines.Infra.ORM.Shared;

namespace SpotyMaines.Configuration
{
    public static class DependencyInjectionConfigExtension
    {
        public static void AddConfigureDependecyInjection(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            //string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            services.AddDbContext<IPersistenceContext, SpotyMainesDbContext>(optBuilder =>
            {
                optBuilder.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
            })
               .AddEntityFrameworkStores<SpotyMainesDbContext>()
               .AddDefaultTokenProviders();

            services.AddTransient<ITenantProvider, ApiTenantProvider>();
        }
    }
}
