using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Promocodes.Business.Exceptions;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(ErrorJson(404, ex.Message));
            }
            catch (UpdateException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(ErrorJson(404, ex.Message));
            }
            catch (EntityValidationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(ErrorJson(400, ex.ValidationErrorMessages));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(ErrorJson(500, "Internal server error"));

                _logger.LogError(ex, ex.Message, null);
            }
        }

        private static object ErrorJson(int code, params string[] message) => new();
    }
}
