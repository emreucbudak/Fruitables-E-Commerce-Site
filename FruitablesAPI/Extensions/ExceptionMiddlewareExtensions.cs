using Entities.ErrorDetails;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Interfaces;

namespace FruitablesAPI.Extensions
{
    public class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionHandler (WebApplication app, ILoggerService _lg)
        {
            app.UseExceptionHandler(apperror =>
            {
                apperror.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    if (feature != null)
                    {
                        context.Response.StatusCode = feature.Error switch
                        {
                            NotFoundExceptions => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        _lg.LogError($"Something went wrong! {feature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            ErrorMessage = feature.Error.Message

                        }.ToString() );
                    }

                });
            });
        }
    }
}
