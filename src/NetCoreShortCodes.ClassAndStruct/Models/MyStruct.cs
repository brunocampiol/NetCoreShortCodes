namespace NetCoreShortCodes.ClassAndStruct.Models
{
    // Struct is a value type
    public struct MyStruct
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public MyStruct()
        {
            Id = Guid.NewGuid();
        }
    }
}