namespace SpotyMaines.Configuration.AutoMapperConfig
{
    public static class AutoMapperConfigExtension
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<UserProfile>();
            });
        }
    }
}
