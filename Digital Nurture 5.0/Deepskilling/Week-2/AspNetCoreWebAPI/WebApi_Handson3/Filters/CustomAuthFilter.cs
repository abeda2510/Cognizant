using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext context)
        {
            var authorizationHeader =
                context.HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Result = new BadRequestObjectResult(
                    "Invalid request - No Auth token"
                );

                return;
            }

            if (!authorizationHeader.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult(
                    "Invalid request - Token present but Bearer unavailable"
                );

                return;
            }

            base.OnActionExecuting(context);
        }
    }
}