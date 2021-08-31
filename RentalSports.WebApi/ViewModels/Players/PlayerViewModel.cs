using RentalSports.Domain.Entities;
using System;

namespace RentalSports.WebApi.ViewModels.Players
{
    public class PlayerViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public DateTime Birth { get; set; }

        public int Age { get; set; }

        public string MobileNumber { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string AvatarUrl { get; set; }

        public static implicit operator PlayerViewModel(Player player)
            => new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Email = player.Email,
                Description = player.Description,
                Height = player.Height,
                Weight = player.Weight,
                Birth = player.Birth,
                Age = player.CalculateAge(),
                MobileNumber = player.MobileNumber,
                Latitude = player.Location.Latitude,
                Longitude = player.Location.Longitude,
                AvatarUrl = player.AvatarUrl
            };
    }
}
