namespace NetCoreShortCodes.API.Models.Entity
{
    public class User
    {
        //public Guid Id { get; init; } = Guid.NewGuid();
        //public bool IsActive { get; init; }
        public int Karma { get; init; }
        public string UserName { get; init; } = default!;
        // TODO fix the dateonly in sqlite
        //public DateOnly? DateOfBirth { get; init; }
        //public DateTime DateCreated { get; init; } = DateTime.UtcNow;
    }
}