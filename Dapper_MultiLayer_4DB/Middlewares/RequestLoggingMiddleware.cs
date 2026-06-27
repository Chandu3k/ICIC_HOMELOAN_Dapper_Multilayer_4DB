using BussinessEntites.Interfaces.ILogs;
using BussinessEntites.Models.ModelLogs;
using Serilog;

namespace ICICBank_HomeLoan.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingFactory _loggingFactory;
        public RequestLoggingMiddleware(RequestDelegate next,ILoggingFactory loggerFactory)
        {
            _next = next;//Constructr Injection
            _loggingFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Log.Information($"Request path:{context.Request.Path}");
            await _next(context);
            Log.Information($"Response Status Code: {context.Response.StatusCode}");

        }

    }
}
