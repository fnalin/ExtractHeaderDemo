using ExtractHeaderDemo.Api.Models;
using Microsoft.Extensions.Primitives;

namespace ExtractHeaderDemo.Api.Middlewares;

public class ExtractCustomHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public ExtractCustomHeaderMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, DemoDI demoDi)
    {
        const string headerKeyName = "x-company-id-middleware";
        context.Request.Headers.TryGetValue(headerKeyName, out StringValues headerValue);

        demoDi.XCompanyId = headerValue;

        await _next(context);
    }
}