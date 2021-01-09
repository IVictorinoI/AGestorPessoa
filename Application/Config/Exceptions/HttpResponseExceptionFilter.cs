using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Config.Exceptions
{
    //https://docs.microsoft.com/pt-br/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                OnException(context, httpResponseException);
                return;
            }

            if (context.Exception is Exception exception)
            {
                OnException(context, context.Exception);
                return;
            }
        }

        private void OnException(ActionExecutedContext context, Exception exception)
        {
            var msg = exception.Message;
            if (exception.InnerException != null)
                msg += exception.InnerException.Message;

            var ret = new
            {
                Code = 0,
                Message = msg
            };

            context.Result = new ObjectResult(ret)
            {
                StatusCode = 400,
            };
            context.ExceptionHandled = true;
        }

        private void OnException(ActionExecutedContext context, HttpResponseException exception)
        {
            var ret = new
            {
                Code = exception.ErrorCode,
                Message = exception.Value
            };

            context.Result = new ObjectResult(ret)
            {
                StatusCode = exception.Status,
            };
            context.ExceptionHandled = true;
        }
    }
}
