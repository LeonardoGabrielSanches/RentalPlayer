using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.DTOs;
using RentalSports.Domain.Interfaces.Services;

namespace RentalSports.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreatePlayer([FromServices] ICreatePlayerService createPlayerService)
        {
            var player = new CreatePlayerDTO()
            {
                Name = "",
                Email = "sleonardogabriel@gmail.com",
                Birth = new System.DateTime(1999, 1, 19),
                Height = 1.78m,
                Weight = 85.36m,
                MobileNumber = "15 996693535",
                Password = "Leonardo123",
                Latitude = -23.5012623m,
                Longitude = -47.4725131m
            };

            var a = createPlayerService.Create(player);

            return Ok(a);
        }
    }
}
