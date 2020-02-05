using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication3StarWars.Cross_Structure.Exceptions;

namespace WebApplication3StarWars.Cross_Structure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _log;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); //First the exception jumps and then this catch it. The execution is stopped :(
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            switch (ex)
            {
                case SplitterException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                case RebelFactoryException _:
                    code = HttpStatusCode.Forbidden;
                    break;
                case RegisterException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                case ControllerException _:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result); 
        }
    }
}
