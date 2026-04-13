using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Queries
{
    public record GetUserByEmail(string email) : IRequest<UserDto?>
    {
    }
}
