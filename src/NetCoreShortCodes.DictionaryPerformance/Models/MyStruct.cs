namespace NetCoreShortCodes.DictionaryPerformance.Models
{
    internal struct MyStruct
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public MyStruct()
        {
            Id = Guid.NewGuid();
        }
    }
}