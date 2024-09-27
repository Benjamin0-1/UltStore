using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltStore.Application.Core.Authentication.Commands;
using System.Threading.Tasks;
using UltStore.Application.Core.Authentication.Queries;

// endpoints
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    // constructor
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // endpoints...
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile([FromQuery] GetProfile query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}