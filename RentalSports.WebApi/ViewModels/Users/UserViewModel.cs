using RentalSports.Domain.Entities;

namespace RentalSports.WebApi.ViewModels.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string AvatarUrl { get; set; }

        public static UserViewModel MapUserViewModel(User user, string token)
            => new UserViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Token = token,
                AvatarUrl = user.AvatarUrl
            };
    }
}
