using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string errorMessage =
                $"Exception: {context.Exception.Message}" +
                $"{Environment.NewLine}" +
                $"Date: {DateTime.Now}";

            File.AppendAllText(
                "ExceptionLog.txt",
                errorMessage + Environment.NewLine
            );

            context.Result = new ObjectResult(
                context.Exception.Message
            )
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}