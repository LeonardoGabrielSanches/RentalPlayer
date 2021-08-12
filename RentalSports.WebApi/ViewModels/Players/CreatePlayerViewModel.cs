using System;
using System.ComponentModel.DataAnnotations;
using RentalSports.Domain.Entities;
using RentalSports.Domain.ValueObject;

namespace RentalSports.WebApi.ViewModels.Players
{
    public class CreatePlayerViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' deve estar preenchido.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um email.")]
        [Required(ErrorMessage = "O campo 'Email' deve estar preenchido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' deve estar preenchido.")]
        public string Password { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "O campo 'Altura' deve ser maior que zero.")]
        public decimal Height { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "O campo 'Peso' deve ser maior que zero.")]
        public decimal Weight { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo 'Nascimento' deve ser uma data.")]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' deve estar preenchido.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "O campo 'Latitude' deve estar preenchido.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "O campo 'Longitude' deve estar preenchido.")]
        public decimal Longitude { get; set; }

        public static implicit operator Player(CreatePlayerViewModel createPlayerViewModel)
            => new Player(
                name: createPlayerViewModel.Name,
                email: createPlayerViewModel.Email,
                password: createPlayerViewModel.Password,
                height: createPlayerViewModel.Height,
                weight: createPlayerViewModel.Weight,
                birth: createPlayerViewModel.Birth,
                mobileNumber: createPlayerViewModel.MobileNumber,
                location: new Location(latitude: createPlayerViewModel.Latitude,
                                       longitude: createPlayerViewModel.Longitude));
    }
}
