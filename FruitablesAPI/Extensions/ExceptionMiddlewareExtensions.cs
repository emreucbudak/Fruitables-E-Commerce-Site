using Entities.ErrorDetails;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Interfaces;

namespace FruitablesAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService _lg)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    if (feature != null)
                    {
                        context.Response.StatusCode = feature.Error switch
                        {
                            NotFoundExceptions => StatusCodes.Status404NotFound,
                            ValidationResultExceptions => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        _lg.LogError($"Something went wrong {feature.Error}");

                        // Eğer hata tipi ValidationResultExceptions ise, hata mesajlarını liste olarak döndür
                        var errorMessages = feature.Error switch
                        {
                            ValidationResultExceptions validationError => validationError.Message.Split('\n').ToList(),
                            _ => new List<string> { feature.Error.Message }
                        };

                        var errorDetails = new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            ErrorMessage = errorMessages
                        };

                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }
    }
}
