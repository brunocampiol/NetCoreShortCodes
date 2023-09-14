using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace NetCoreShortCodes.API.Configuration
{
    public static class SwaggerConfiguration
    {
        internal static void AddAppSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.MapType<char>(() => new OpenApiSchema
                {
                    Type = "string",
                    MinLength = 1,
                    MaxLength = 1
                });
                options.MapType<TimeOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Pattern = "^(?:[01]\\d|2[0-3]):[0-5]\\d:[0-5]\\d(?:\\.\\d{1,7})?$",
                    Example = new OpenApiString(DateTime.Now.ToString("HH:mm:ss.fffffff"))
                });
                options.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Pattern = "^(\\d{1,7}\\.)?([01]\\d|2[0-3]):([0-5]\\d):([0-5]\\d)(?:\\.(\\d{1,7}))?$",
                    Example = new OpenApiString(DateTime.Now.ToString("d.HH:mm:ss.fffffff"))
                });
                options.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFF"))
                });
                options.MapType<DateTimeOffset>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString(DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFzzz"))
                });
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Example API",
                    Description = "Example API",
                    Contact = new OpenApiContact
                    {
                        Name = "BrunoCampiol",
                        Url = new Uri("https://brunocampiol.github.io/about.html")
                    }
                });
                var xmlFilename = $"{typeof(Program).Assembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}