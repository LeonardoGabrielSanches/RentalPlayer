namespace RentalSports.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        protected User() { }

        protected User(string id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        protected User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        protected User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}
