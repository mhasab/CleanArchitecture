using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Queries
{
    public record GetAllUsers() : IRequest<List<UserDto>>;
}
