using Microsoft.AspNetCore.Http;
using RentalSports.Domain.Entities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentalSports.WebApi.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserAuthenticated _userAuthenticated;

        public UserMiddleware(RequestDelegate next,
                              UserAuthenticated userAuthenticated)
        {
            _next = next;
            _userAuthenticated = userAuthenticated;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                string email = httpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                string id = httpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                _userAuthenticated.UpdateInMiddlewareAuthentication(id, email);
            }

            await _next(httpContext);
        }
    }
}
