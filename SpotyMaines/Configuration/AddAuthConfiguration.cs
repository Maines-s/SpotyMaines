﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SpotyMaines.Configuration
{
    public static class AddAuthConfiguration
    {
        public static void AddAuthConfigurationMathod(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("SegredoSpotyMaines");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = "http://localhost",
                    ValidIssuer = "SpotyMaines"
                };
            });
        }
    }
}
