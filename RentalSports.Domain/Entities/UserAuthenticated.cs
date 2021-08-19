using System;

namespace RentalSports.Domain.Entities
{
    public class UserAuthenticated
    {
        public UserAuthenticated() { }

        public string Id { get; private set; }
        public string Email { get; private set; }

        public void UpdateInMiddlewareAuthentication(string id,
                                                     string email)
        {
            Id = id;
            Email = email;
        }
    }
}
