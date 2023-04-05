using Microsoft.Extensions.Options;
using NetCoreShortCodes.OptionsValidation.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOptions<ExampleDataAnnotationsOptions>()
                .Bind(config.GetRequiredSection(ExampleDataAnnotationsOptions.SectionName))
                //.Validate(x =>
                //{
                //    if (x.Retries <= 0)
                //    {
                //        return false;
                //    }

                //    return true;
                //})
                .ValidateDataAnnotations()
                .ValidateOnStart();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/", (IOptions<ExampleDataAnnotationsOptions> options) => options.Value.Message);

app.Run();