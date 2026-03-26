using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserById(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpGet("age-range")]
        public async Task<IActionResult> GetByAgeRange(int minAge, int maxAge)
        {
            var users = await _userService.GetUsersByAgeRangeAsync(minAge, maxAge);
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest("Failed to create user.");
            return Ok(result);
        }
    }
}
