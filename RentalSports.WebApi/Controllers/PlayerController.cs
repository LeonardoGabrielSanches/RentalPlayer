using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.WebApi.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace RentalSports.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class PlayerController : MainController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<PlayerViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll([FromServices] IPlayerRepository playerRepository)
        {
            var players = playerRepository.GetAll();

            if (!players.Any())
                return NotFound();

            return CustomResponse(players.Select(player => (PlayerViewModel)player));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public IActionResult CreatePlayer([FromServices] ICreatePlayerService createPlayerService,
                                          [FromBody] CreatePlayerViewModel createPlayerViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var player = createPlayerService.Create(createPlayerViewModel);

            if (player.Invalid)
                return CustomResponse(player);

            return Created(string.Empty, (PlayerViewModel)player);
        }
    }
}
