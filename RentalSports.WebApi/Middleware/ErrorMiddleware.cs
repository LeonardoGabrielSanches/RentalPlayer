using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RentalSports.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RentalSports.WebApi.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await HandleDomainException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleDomainException(HttpContext context, DomainException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = new
            {
                context.Response.StatusCode,
                Errors = new List<string>() { exception.Message },
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred whilst processing your request",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
