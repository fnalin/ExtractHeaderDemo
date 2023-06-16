using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ExtractHeaderDemo.Api.Models;

public class HeaderDto
{
    [FromHeader(Name="x-company-id")]
    public string? XCompanyId { get; set; } = null;
}