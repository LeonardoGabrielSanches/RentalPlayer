using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.WebApi.ViewModels.Players;

namespace RentalSports.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PlayerController : MainController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePlayer([FromServices] ICreatePlayerService createPlayerService,
                                          [FromBody] CreatePlayerViewModel createPlayerViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var player = createPlayerService.Create(createPlayerViewModel);

            if (player.Invalid)
                return CustomResponse(player);

            return Created(string.Empty, player);
        }
    }
}
