using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUsers());

            if (!result.Success)
                return StatusCode(StatusCodes.Status403Forbidden, result);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserById(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var result = await _mediator.Send(new GetCurrentUserQuery());

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("age-range")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetByAgeRange(int minAge, int maxAge)
        {
            var users = await _userService.GetUsersByAgeRangeAsync(minAge, maxAge);
            return Ok(users);
        }

        [HttpPost("create")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                if (result.Message == "User already exists.")
                    return Conflict(result); // 409

                return BadRequest(result); // 400
            }

            return Ok(result);
        }
    }
}
