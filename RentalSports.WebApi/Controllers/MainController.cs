using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace RentalSports.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class MainController : ControllerBase
    {
        private readonly List<string> _errors = new List<string>();

        protected ActionResult CustomResponse(object result = default)
        {
            if (OperationValid())
                return Ok(result);

            return BadRequest(new { Errors = _errors });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected bool OperationValid()
            => !_errors.Any();

        protected void AddError(string erro)
            => _errors.Add(erro);
    }
}
