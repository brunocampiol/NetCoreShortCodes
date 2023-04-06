namespace NetCoreShortCodes.OptionsValidation.Options
{
    public class ExampleFluentOptions
    {
        public const string SectionName = "ExampleFluentOptions";

        public LogLevel LogLevel { get; init; }
        public int Retries { get; init; }
        public string Message { get; init; }
    }
}