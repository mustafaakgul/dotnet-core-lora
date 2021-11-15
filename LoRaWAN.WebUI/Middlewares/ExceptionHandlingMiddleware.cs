/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Logging.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ResponseStates.Enums;
using ResponseStates.Exceptions;
using ResponseStates.Extensions;
using ResponseStates.Models;
using WebUI.Exception.Models;
using WebUI.Models;

namespace WebUI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env, ILogManager logger)
        {
            try
            {
                var result = _next(httpContext);
                await result;
            }
            catch (StateException ex)
            {
                await HandleExceptionAsync(httpContext, logger, ex, env);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, logger, ex, env);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(httpContext, logger, ex, env);
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
            var status = new ResponseState(exception.StateCode);

            //LOGLAMA İŞLEMİ YAPILACAK

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status.Status.StateCode.GetStateCode();
            return context.Response.WriteAsync(status.ToString());
        }

        private async Task HandleExceptionAsync(HttpContext context, ILogManager logger, System.Exception exception, IWebHostEnvironment env)
        {
            var response = new ResponseState<ExceptionMessageModel>()
            {
                Status = new Status(StateCode.WebUIUnexpectedError),
                Content = new ExceptionMessageModel()
                {
                    Data = new StreamReader(context.Request.Body).ReadToEnd(),
                    ErrorType = exception.GetType().Name,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    InnerException = GetInnerExceptionMessages(exception.InnerException)
                }
            };

            context.Response.StatusCode = response.Status.Code;
            if (context.Request.Body.CanSeek)
                context.Request.Body.Position = 0;

            //Logging
            logger.Error(response, "Error");
            await _next(context);
        }

        private static ExceptionMessageModel GetInnerExceptionMessages(System.Exception exception)
        {
            if (exception == null) return null;
            return new ExceptionMessageModel
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerException = GetInnerExceptionMessages(exception.InnerException)
            };
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
*/