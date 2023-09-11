namespace NetCoreShortCodes.API.Models.Entity
{
    public class SqliteSupportedNetTypes
    {
        public bool MyBool { get; init; }
        public byte MyByte { get; init; }
        public char MyChar { get; init; }
        public DateOnly MyDateOnly { get; init; }
        public DateTime MyDateTime { get; init; }
        public DateTimeOffset MyDateTimeOffset { get; init; }
        public decimal MyDecimal { get; init; }
        public double MyDouble { get; init; }
        public Guid MyGuid { get; init; }
        public int MyInt { get; init; }
        public string MyString { get; init; } = default!;
        public TimeOnly MyTimeOnly { get; init; }
        public TimeSpan MyTimeSpan { get; init; }
    }
}