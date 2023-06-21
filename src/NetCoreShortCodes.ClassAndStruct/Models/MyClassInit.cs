namespace NetCoreShortCodes.ClassAndStruct.Models
{
    public class MyClassInit
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = default!;
    }
}