using Microsoft.AspNetCore.Mvc;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.WebApi.ViewModels.Players;

namespace RentalSports.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class MeController : MainController
    {
        [HttpGet]
        public IActionResult Me([FromServices] IMeInfoService meInfoService)
        {
            var me = meInfoService.Get();

            return Ok((PlayerViewModel)me);
        }
    }
}
