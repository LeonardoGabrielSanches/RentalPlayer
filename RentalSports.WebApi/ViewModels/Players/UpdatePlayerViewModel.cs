using RentalSports.Domain.Entities;
using RentalSports.Domain.ValueObject;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalSports.WebApi.ViewModels.Players
{
    public class UpdatePlayerViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' deve estar preenchido.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um email.")]
        [Required(ErrorMessage = "O campo 'Email' deve estar preenchido.")]
        public string Email { get; set; }

        [Range(0, 300, ErrorMessage = "O campo 'Altura' deve ser maior que zero.")]
        public decimal Height { get; set; }

        [Range(0, 300, ErrorMessage = "O campo 'Peso' deve ser maior que zero.")]
        public decimal Weight { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo 'Nascimento' deve ser uma data.")]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' deve estar preenchido.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "O campo 'Latitude' deve estar preenchido.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "O campo 'Longitude' deve estar preenchido.")]
        public decimal Longitude { get; set; }

        public static implicit operator Player(UpdatePlayerViewModel updatePlayerViewModel)
            => new Player(
                name: updatePlayerViewModel.Name,
                email: updatePlayerViewModel.Email,
                password: string.Empty,
                height: updatePlayerViewModel.Height,
                weight: updatePlayerViewModel.Weight,
                birth: updatePlayerViewModel.Birth,
                mobileNumber: updatePlayerViewModel.MobileNumber,
                location: new Location(latitude: updatePlayerViewModel.Latitude,
                                       longitude: updatePlayerViewModel.Longitude));
    }
}
