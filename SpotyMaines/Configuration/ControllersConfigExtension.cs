using System.Text.Json.Serialization;
using System.Text.Json;

namespace SpotyMaines.Configuration
{
    public static class ControllersConfigExtension
    {
        public static void AddControllerAddConfig(this IServiceCollection services)
        {
            services.AddControllers(config => {
                config.Filters.Add<SerilogActionFilter>();
            }).AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverterJson()));
        }
    }

    public class TimeSpanToStringConverterJson : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
