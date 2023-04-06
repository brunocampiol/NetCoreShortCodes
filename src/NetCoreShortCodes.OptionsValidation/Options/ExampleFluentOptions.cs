namespace NetCoreShortCodes.OptionsValidation.Options
{
    // Example class that validates using fluent validation - Requires more code
    // ExampleFluentOptionsValidator.cs
    // FluentValidationOptions.cs
    // OptionsBuilderFluentValidationExtensions.cs
    // Lastly, .ValidateFluently() on Program.cs
    public class ExampleFluentOptions
    {
        public const string SectionName = "ExampleFluentOptions";

        public LogLevel LogLevel { get; init; }
        public int Retries { get; init; }
        public string Message { get; init; }
    }
}