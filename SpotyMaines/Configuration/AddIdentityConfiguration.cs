using Microsoft.AspNetCore.Identity;
using SpotyMaines.Domain.AutenticationModule;
using SpotyMaines.Infra.ORM.Shared;

namespace SpotyMaines.Configuration
{
    public static class AddIdentityConfiguration
    {
        public static void AddIdentityConfigurationMethod(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
               .AddEntityFrameworkStores<SpotyMainesDbContext>()
               .AddDefaultTokenProviders()
               .AddErrorDescriber<IdentityErrorDescriber>();
        }
    }
}
