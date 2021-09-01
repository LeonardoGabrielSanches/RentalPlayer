namespace RentalSports.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        protected User() { }

        protected User(string id, string name, string email, string password, string avatarUrl)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            AvatarUrl = avatarUrl;
        }

        protected User(string name, string email, string password, string avatarUrlr)
        {
            Name = name;
            Email = email;
            Password = password;
            AvatarUrl = avatarUrlr;
        }

        protected User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string AvatarUrl { get; protected set; }
    }
}
