using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.WebApi.ViewModels.Players;

namespace RentalSports.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePlayer([FromServices] ICreatePlayerService createPlayerService,
                                          [FromBody] CreatePlayerViewModel createPlayerViewModel)
        {
            var player = createPlayerService.Create(createPlayerViewModel);

            if (player.Invalid)
                return BadRequest(new { message = player.NotificationError });

            return Created(string.Empty, player);
        }
    }
}
