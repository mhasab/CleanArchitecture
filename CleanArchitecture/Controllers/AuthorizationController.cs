using Application.DTOs;
using Application.Features.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var token = await _mediator.Send(
                new LoginCommand(request.Email, request.Password)
            );

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}
