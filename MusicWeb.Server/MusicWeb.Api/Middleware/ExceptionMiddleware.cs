using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                string errorMessage = "";
                PrepareErrorMessage(ex, errorMessage);

                //httpContext.Response.Redirect("/Error");
            }
        }

        private string PrepareErrorMessage(Exception ex, string errorMessage)
        {
            if (ex.InnerException != null)
                PrepareErrorMessage(ex.InnerException, errorMessage);

            errorMessage = ex.Message + Environment.NewLine;
            return errorMessage;
        }
    }
}
