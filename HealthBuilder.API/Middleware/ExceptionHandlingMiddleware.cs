using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HealthBuilder.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        //pull
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    default:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = $"Exception thrown: {error.Message}"});
                await response.WriteAsync(result);
            }
        }
    }
}