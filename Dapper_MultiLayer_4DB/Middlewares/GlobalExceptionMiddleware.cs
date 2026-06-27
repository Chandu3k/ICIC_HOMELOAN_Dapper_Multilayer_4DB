using BussinessEntites.Interfaces.ILogs;
using BussinessEntites.Models.ModelLogs;
using DBConnectivity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Text.Json.Serialization;

namespace ICICBank_HomeLoan.Middlewares
{
    // Purpose:
    // 1. Catch all unhandled exceptions from Controllers/Services/Repositories.
    // 2. Save logs into database.
    // 3. Save logs into Serilog file.
    // 4. Return a friendly JSON error response to the client.
    public class GlobalExceptionMiddleware
    {
        // Holds reference to the next middleware/component in the pipeline.
        private readonly RequestDelegate _next;

        // Used to save logs into database tables.
        private readonly ILoggingFactory _loggerFactory;
        public GlobalExceptionMiddleware(RequestDelegate next, ILoggingFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        // Every HTTP request enters this method.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Pass request to next middleware/controller.
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case AppException:
                        // Custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        // Not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException:
                        // Unauthorized error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // Unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var errorLog = (new ProjectLevelErrorLog
                {
                    StatusCode = response.StatusCode.ToString(),
                    ErrorMessage = error?.Message,
                    StackTraceError = error?.StackTrace,
                    InnerExceptionError = error?.InnerException?.ToString(),
                    UserName = "Chandu"
                });
                await _loggerFactory.ProjectLevelErrorLogAsync(errorLog);
                Log.Error("Custom Failure: {@StatusCode},{@ErrorMessage},{@StackTraceError},{@InnerExceptionError}",
                    errorLog.StatusCode,
                    errorLog.ErrorMessage,
                    errorLog.StackTraceError,
                    errorLog.InnerExceptionError);

                await _loggerFactory.AddLoggingMessagesAsync(
                    new ProjectLevelLog
                    {
                        UserName = "Chandu",
                        LogLevel = "Information",
                        MessageTemplate =error.Message
                    });


                var errorFriendlyMessage = new ProblemDetails
                {
                    Type = "API Exception",
                    Status = response.StatusCode,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please contact support.",

                };
                // Convert object to JSON
                var result = JsonConvert.SerializeObject(errorFriendlyMessage);

                // Return JSON response
                await response.WriteAsync(result);



            }
        }
    }
}
