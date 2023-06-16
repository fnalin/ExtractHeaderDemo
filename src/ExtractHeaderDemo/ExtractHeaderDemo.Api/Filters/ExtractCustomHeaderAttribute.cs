using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace ExtractHeaderDemo.Api.Filters;

public class ExtractCustomHeaderAttribute : ActionFilterAttribute
{
   public override void OnActionExecuting(ActionExecutingContext context)
   {
      const string headerKeyName = "x-company-id";
      context.HttpContext.Request.Headers.TryGetValue(headerKeyName, out StringValues headerValue);
      
      context.HttpContext.Items[headerKeyName] = headerValue;
   }
}