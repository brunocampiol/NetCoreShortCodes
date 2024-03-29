﻿using System.ComponentModel.DataAnnotations;

namespace NetCoreShortCodes.OptionsValidation.Options
{
    // Example class that requires the .ValidateDataAnnotations() on Program.cs
    public class ExampleDataAnnotationsOptions
    {
        public const string SectionName = "ExampleDataAnnotationsOptions";

        [EnumDataType(typeof(LogLevel))]
        public LogLevel LogLevel { get; init; }
        [Range(1,10)]
        public int Retries { get; init; }
        [Required]
        public string Message { get; init; }
    }
}