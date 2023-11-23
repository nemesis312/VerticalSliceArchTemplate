using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArch.Application.Features.Users.Command;
using VerticalSliceArch.Domain.DTOs;
using VerticalSliceArch.Infrastructure.Services.shared;

namespace VerticalSliceArch.Presentation.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITenantService _tenantService;
    public UserController(IMediator mediator, ITenantService tenantService)
    {
        _mediator = mediator;
        _tenantService = tenantService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto)
    {
        var command = new CreateUserCommand { UserDto = userDto, TenantId = _tenantService.GetTenantId() };
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
}