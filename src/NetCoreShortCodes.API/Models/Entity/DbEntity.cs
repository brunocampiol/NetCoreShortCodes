namespace NetCoreShortCodes.API.Models.Entity
{
    /// <summary>
    /// Example entity for SQL lite
    /// </summary>
    public class DbEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public DbEntity()
        {
            Value = string.Empty;
        }

        public DbEntity(int id, string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            Id = id;
            Value = value;
        }
    }
}