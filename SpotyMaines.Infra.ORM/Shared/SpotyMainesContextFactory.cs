using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Infra.ORM.Shared
{
    public class SpotyMainesContextFactory : IDesignTimeDbContextFactory<SpotyMainesDbContext>
    {
        public SpotyMainesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SpotyMainesDbContext>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //string connectionString = config.GetConnectionString("SqlServer");

            string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            builder.UseSqlServer(connectionString);

            return new SpotyMainesDbContext(builder.Options);
        }
    }
}
