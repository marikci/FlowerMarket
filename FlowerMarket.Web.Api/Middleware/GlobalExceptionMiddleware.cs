using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

namespace FlowerMarket.Web.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private static readonly Serilog.ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();

        public GlobalExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.Error($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");

            return Task.CompletedTask;
        }
    }
}
