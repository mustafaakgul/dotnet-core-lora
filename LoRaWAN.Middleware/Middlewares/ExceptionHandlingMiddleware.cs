using Logging.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using ResponseStates.Enums;
using ResponseStates.Exceptions;
using ResponseStates.Extensions;
using ResponseStates.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MWAtlas.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env, ILogManager logger)
        {
            try
            {
                await _next(context);
            }
            catch (StateException ex)
            {
                await HandleExceptionAsync(context, logger, ex, env);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, logger, ex, env);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, logger, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, ILogManager logger, ValidationException exception, IWebHostEnvironment env)
        {
            var status = new ResponseState<Dictionary<string, string>>(exception.StateCode)
            {
                Content = exception.ValidationErrors
            };

            //LOGLAMA İŞLEMİ YAPILACAK

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status.Status.StateCode.GetStateCode();
            return context.Response.WriteAsync(status.ToString());
        }

        private static Task HandleExceptionAsync(HttpContext context, ILogManager logger, StateException exception, IWebHostEnvironment env)
        {
            var status = new ResponseState(exception.StateCode, exception.Messages);

            //LOGLAMA İŞLEMİ YAPILACAK

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status.Status.StateCode.GetStateCode();
            return context.Response.WriteAsync(status.ToString());
        }

        private static Task HandleExceptionAsync(HttpContext context, ILogManager logger, Exception exception, IWebHostEnvironment env)
        {
            var status = new ResponseState(StateCode.UnexpectedError);

            //LOGLAMA İŞLEMİ YAPILACAK

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status.Status.StateCode.GetStateCode();
            return context.Response.WriteAsync(status.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
