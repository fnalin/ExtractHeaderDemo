using ExtractHeaderDemo.Api.Filters;
using ExtractHeaderDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ExtractHeaderDemo.Api.Controllers;

[Route("headers")]
[ApiController]
public class HeadersController : ControllerBase
{
    private readonly ILogger<HeadersController> _logger;
    public HeadersController(ILogger<HeadersController> logger) => _logger = logger;

    [HttpGet("from-basic")]
    public IActionResult FromBasic()
    {
        const string headerKeyName = "x-company-id"; 
        Request.Headers.TryGetValue(headerKeyName, out StringValues headerValue); 
        return Ok(headerValue); 
    }
    
    [HttpGet("from-attribute")]
    public IActionResult ExtractFromQueryAttribute([FromHeader] HeaderDto headerDto)
    {
        return Ok(headerDto);
    }
    
    [HttpGet("from-filter")]
    [ExtractCustomHeader]
    public IActionResult ExtractFromFilter()
    {
        const string headerKeyName = "x-company-id";
        HttpContext.Items.TryGetValue(headerKeyName, out object? filterHeaderValue);
        return Ok(filterHeaderValue);
    }
    
    [HttpGet("from-middleware")]
    public IActionResult FromMiddleware([FromServices]DemoDI demoDi)
    {
        return Ok(demoDi.XCompanyId); 
    }

}