using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RentalSports.Domain.Entities;
using RentalSports.Domain.ValueObject;
using RentalSports.Infra.Data.MongoDB.Constants;
using System;

namespace RentalSports.Infra.Data.MongoDB.Documents
{
    public class PlayerDocument
    {
        public ObjectId Id { get; set; }

        [BsonElement(PlayerConstants.Name)]
        public string Name { get; set; }

        [BsonElement(PlayerConstants.Email)]
        public string Email { get; set; }

        [BsonElement(PlayerConstants.Password)]
        public string Password { get; set; }

        [BsonElement(PlayerConstants.Description)]
        public string Description { get; set; }

        [BsonElement(PlayerConstants.Height)]
        public decimal Height { get; set; }

        [BsonElement(PlayerConstants.Weight)]
        public decimal Weight { get; set; }

        [BsonElement(PlayerConstants.Birth)]
        public DateTime Birth { get; set; }

        [BsonElement(PlayerConstants.MobileNumber)]
        public string MobileNumber { get; set; }

        [BsonElement(PlayerConstants.Latitude)]
        public decimal Latitude { get; set; }

        [BsonElement(PlayerConstants.Longitude)]
        public decimal Longitude { get; set; }

        [BsonElement(PlayerConstants.AvatarUrl)]
        public string AvatarUrl { get; set; }

        public static implicit operator PlayerDocument(Player player)
            => new PlayerDocument()
            {
                Id = string.IsNullOrEmpty(player.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(player.Id),
                Name = player.Name,
                Email = player.Email,
                Password = player.Password,
                Description = player.Description,
                Height = player.Height,
                Weight = player.Weight,
                Birth = player.Birth,
                MobileNumber = player.MobileNumber,
                Latitude = player.Location.Latitude,
                Longitude = player.Location.Longitude,
                AvatarUrl = player.AvatarUrl
            };

        public static implicit operator Player(PlayerDocument playerDocument)
        {
            if (playerDocument == null)
                return new Player();

            return new Player(
                id: playerDocument.Id.ToString(),
                name: playerDocument.Name,
                email: playerDocument.Email,
                password: playerDocument.Password,
                description: playerDocument.Description,
                height: playerDocument.Height,
                weight: playerDocument.Weight,
                birth: playerDocument.Birth,
                mobileNumber: playerDocument.MobileNumber,
                location: new Location(latitude: playerDocument.Latitude,
                                       longitude: playerDocument.Longitude),
                avatarUrl: playerDocument.AvatarUrl);
        }
    }
}
