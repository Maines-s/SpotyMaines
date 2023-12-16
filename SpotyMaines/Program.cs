
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotyMaines.Application.AuthModule;
using SpotyMaines.Configuration;
using SpotyMaines.Configuration.AutoMapperConfig;
using SpotyMaines.Domain.AutenticationModule;
using SpotyMaines.Infra.ORM.Shared;
using System.Text;

namespace SpotyMaines
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddTransient<AuthService>();
            builder.Services.AddTransient<UserManager<User>>();
            builder.Services.AddIdentityConfigurationMethod();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapperConfig();
            builder.Services.AddConfigureDependecyInjection(builder.Configuration);
            builder.Services.AddSerilogConfig(builder.Logging);
            builder.Services.AddControllerAddConfig();
            builder.Services.AddSwaggerConfig();
            builder.Services.AddAuthConfigurationMathod();

            var app = builder.Build();

            app.UseCors("AllowAllOrigins");

            app.UseAuthentication();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}