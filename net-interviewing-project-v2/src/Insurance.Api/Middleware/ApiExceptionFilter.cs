using Insurance.Domain.Entities.Utility.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Insurance.Api.Middleware
{
    public class ApiExceptionFilter: ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                context.Exception = null;

                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;

                _logger.LogWarning(context.Exception.GetBaseException().Message);
            }
            else if (context.Exception is NotFoundException)
                                                                                                                                                                                                                                                                                                                            {
                var msg = context.Exception.GetBaseException().Message;
                context.HttpContext.Response.StatusCode = 404;
                apiError = new ApiError(msg);

                _logger.LogWarning(msg);
            }
            else
            {
#if !DEBUG
                var msg = "An unhandled error occurred.";                
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg)
                {
                    Detail = stack
                };

                context.HttpContext.Response.StatusCode = 500;

                _logger.LogError(msg, stack);
            }

            // always return a JSON result
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
