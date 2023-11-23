using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArch.Features.TimeConvertion.Application.Command;
using VerticalSliceArch.Features.TimeConvertion.Application.Queries;
using VerticalSliceArch.Infrastructure.Services.shared;

namespace VerticalSliceArch.Features.TimeConvertion.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeConversionController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITenantService _tenantService;
    
    public TimeConversionController(IMediator mediator, ITenantService tenantService)
    {
        _mediator = mediator;
        _tenantService = tenantService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetTimeConversionQuery { Id = 1 };
        var time = await _mediator.Send(query);
        return Ok(time);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] int seconds)
    {
        var command = new SaveTimeConvertionCommand { Seconds = seconds, TenantId = _tenantService.GetTenantId() };
        var timeId = await _mediator.Send(command);
        return Ok(timeId);
    }
    
}