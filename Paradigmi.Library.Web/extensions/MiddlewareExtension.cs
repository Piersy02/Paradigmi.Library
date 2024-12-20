﻿using Microsoft.AspNetCore.Diagnostics;
using Paradigmi.Library.Application.Factories;
using System.Net;
using System.Runtime.CompilerServices;

namespace Paradigmi.Library.Web.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            );
                    }
                });
            });

            app.MapControllers();

            return app;

        }
    }
}