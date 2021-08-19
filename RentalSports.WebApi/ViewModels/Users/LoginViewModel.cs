using RentalSports.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RentalSports.WebApi.ViewModels.Users
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um email.")]
        [Required(ErrorMessage = "O campo 'Email' deve estar preenchido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' deve estar preenchido.")]
        public string Password { get; set; }

        public static implicit operator Player(LoginViewModel loginViewModel)
            => new Player(email: loginViewModel.Email,
                          password: loginViewModel.Password);
    }
}
