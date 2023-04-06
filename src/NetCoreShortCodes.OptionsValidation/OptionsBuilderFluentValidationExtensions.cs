using FluentValidation;
using Microsoft.Extensions.Options;

namespace NetCoreShortCodes.OptionsValidation
{
    public static class OptionsBuilderFluentValidationExtensions
    {
        public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
        {
            optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
                s => new FluentValidationOptions<TOptions>(optionsBuilder.Name, s.GetRequiredService<IValidator<TOptions>>()));
            return optionsBuilder;
        }
    }
}