using FluentValidation;
using Microsoft.Extensions.Options;
using NetCoreShortCodes.OptionsValidation;
using NetCoreShortCodes.OptionsValidation.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

//builder.Services.AddOptions<ExampleDataAnnotationsOptions>()
builder.Services.AddOptions<ExampleFluentOptions>()
                .Bind(config.GetRequiredSection(ExampleFluentOptions.SectionName))
                //.Validate(x =>
                //{
                //    if (x.Retries <= 0)
                //    {
                //        return false;
                //    }

                //    return true;
                //})
                //.ValidateDataAnnotations()
                .ValidateFluently()
                .ValidateOnStart();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/", (IOptions<ExampleDataAnnotationsOptions> options) => options.Value.Message);

app.Run();