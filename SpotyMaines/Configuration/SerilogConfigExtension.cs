using Serilog;

namespace SpotyMaines.Configuration
{
    public static class SerilogConfigExtension
    {
        public static void AddSerilogConfig(this IServiceCollection services, ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            Log.Logger.Information("Iniciando aplicação...");

            logging.ClearProviders();

            services.AddSerilog(Log.Logger);
        }
    }
}
