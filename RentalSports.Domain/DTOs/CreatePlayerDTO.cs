using RentalSports.Domain.Entities;
using RentalSports.Domain.ValueObject;
using System;

namespace RentalSports.Domain.DTOs
{
    public class CreatePlayerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime Birth { get; set; }
        public string MobileNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public static implicit operator Player(CreatePlayerDTO createPlayerDTO)
            => new Player(
                name: createPlayerDTO.Name,
                email: createPlayerDTO.Email,
                password: createPlayerDTO.Password,
                height: createPlayerDTO.Height,
                weight: createPlayerDTO.Weight,
                birth: createPlayerDTO.Birth,
                mobileNumber: createPlayerDTO.MobileNumber,
                location: new Location(latitude: createPlayerDTO.Latitude,
                                       longitude: createPlayerDTO.Longitude));
    }
}
