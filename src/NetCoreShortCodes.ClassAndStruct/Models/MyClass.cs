namespace NetCoreShortCodes.ClassAndStruct.Models
{
    // Class is a reference type
    public class MyClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public MyClass(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            Name = name;
        }
    }
}