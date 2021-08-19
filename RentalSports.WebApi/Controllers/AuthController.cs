using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.WebApi.Providers;
using RentalSports.WebApi.ViewModels.Users;

namespace RentalSports.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("v1/[controller]")]
    public class AuthController : MainController
    {
        [HttpPost]
        public IActionResult Login([FromServices] IAuthenticateUserService authenticateUserService,
                                   [FromServices] TokenProvider tokenProvider,
                                   [FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var user = authenticateUserService.AuthenticateUser(loginViewModel);

            if (!user.IsValid)
                return CustomResponse(user);

            var token = tokenProvider.GenerateToken(user);

            return CustomResponse(UserViewModel.MapUserViewModel(user, token));
        }
    }
}
