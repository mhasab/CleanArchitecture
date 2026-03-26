using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Commands
{
    public record CreateUserCommand(string Name, int Age, string Email) : IRequest<UserDto>;
}
