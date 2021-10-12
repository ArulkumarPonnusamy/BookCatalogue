using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using BookCatalogueApi.Application.Exceptions;
using System.Collections.Generic;
using Serilog;

namespace BookCatalogueApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>Middleware Exception Handler.</summary>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>A function that can process an HTTP request and Catch all the exceptions.</summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode httpStatusCode;
            string result;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;

                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;

                    result = JsonConvert.SerializeObject(notFoundException.NotFoundError);
                    break;
                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;

                    result = JsonConvert.SerializeObject(new
                    {
                        error = new CustomErrors
                        {
                            Code = "Internal",
                            Message = "Unknown error occurred while processing the request."
                        }
                    });
                    Log.Error(exception.Message, TraceEventType.Error);
                    break;
            }
            AddErrorDetailsInLogger(result);
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(result);
        }

        private static void AddErrorDetailsInLogger(string errorResponse)
        {
            Log.Error(errorResponse, TraceEventType.Error);
        }
    }
}
