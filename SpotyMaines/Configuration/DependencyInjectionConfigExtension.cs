﻿using Microsoft.EntityFrameworkCore;
using SpotyMaines.Domain.Shared;
using SpotyMaines.Infra.ORM.Shared;

namespace SpotyMaines.Configuration
{
    public static class DependencyInjectionConfigExtension
    {
        public static void AddConfigureDependecyInjection(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config.GetConnectionString("SqlServer");

            string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            services.AddDbContext<IPersistenceContext, SpotyMainesDbContext>(optBuilder =>
            {
                optBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<ITenantProvider, ApiTenantProvider>();

        }
    }
}
