using FluentValidation;
using NetCoreShortCodes.OptionsValidation.Options;

namespace NetCoreShortCodes.OptionsValidation
{
    public class ExampleFluentOptionsValidator : AbstractValidator<ExampleFluentOptions>
    {
        public ExampleFluentOptionsValidator()
        {
            RuleFor(x => x.LogLevel)
                .IsInEnum();

            RuleFor(x => x.Retries)
                .InclusiveBetween(1, 10);

            RuleFor(x => x.Message)
                .NotNull()
                .NotEmpty();
        }
    }
}