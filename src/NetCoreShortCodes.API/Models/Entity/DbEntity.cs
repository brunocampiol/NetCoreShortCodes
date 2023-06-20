namespace NetCoreShortCodes.API.Models.Entity
{
    /// <summary>
    /// Example entity for SQL lite
    /// </summary>
    public class DbEntity
    {
        public int Id { get; init; }
        public string Value { get; init; } = default!;
    }
}